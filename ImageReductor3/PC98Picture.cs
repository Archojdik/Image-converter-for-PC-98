using KGySoft.CoreLibraries;
using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageReductor3;

internal class PC98Picture
{
    private readonly byte[] MAGIC = { 0x6d, 0x61, 0x67, 0x69, 0x63, 0x61 };
    private readonly Color[] TEXT_MODE_COLORS = {
        Color.FromArgb(0, 0, 0),     //grb 000
        Color.FromArgb(0, 0, 255),   //grb 001
        Color.FromArgb(255, 0, 0),   //grb 010
        Color.FromArgb(255, 0, 255), //grb 011
        Color.FromArgb(0, 255, 0),   //grb 100
        Color.FromArgb(0, 255, 255), //grb 101
        Color.FromArgb(255, 255, 0), //grb 110
        Color.FromArgb(255, 255, 255)//grb 111
    };

    public PC98PictureType Type { get; private set; }
    public UInt16 Width { get; private set; }
    public UInt16 Height { get; private set; }

    private Color[]? _palette;
    private Bitmap _convertedBitmap;

    public PC98Picture(Bitmap originalImage, PC98PictureConvertArgs convertArgs)
    {
        Bitmap result = new Bitmap(originalImage);
        Type = convertArgs.Type;

        // Изменяем размер
        result = result.Resize(convertArgs.Size, convertArgs.ScalingMode, convertArgs.KeepAspectRatio);
        Width = (UInt16)convertArgs.Size.Width;
        Height = (UInt16)convertArgs.Size.Height;

        // Уменьшаем количество цветов (в соответствии с типом изображения)
        IQuantizer paletteQuantizer = null;
        switch (Type)
        {
            case PC98PictureType.graphic:
                Bitmap temp = new Bitmap(result);
                temp.Quantize(convertArgs.Quantizer);
                _palette = GetPC98Palette(temp);
                break;
            case PC98PictureType.text:
                _palette = TEXT_MODE_COLORS;
                break;
            default: throw new ArgumentException("Unknown PC-98 picture type.");
        }
        paletteQuantizer = PredefinedColorsQuantizer.FromCustomPalette(_palette);

        // Делаем дизеринг
        result.Dither(paletteQuantizer, convertArgs.Ditherer);
        _convertedBitmap = result;
    }

    public Bitmap GetBitmap() => new Bitmap(_convertedBitmap);
    public void WriteToStream(Stream stream)
    {
        try
        {
            stream.Write(MAGIC);
            stream.WriteByte((byte)Type);
            stream.Write(BitConverter.GetBytes(Width));
            stream.Write(BitConverter.GetBytes(Height));

            if (Type == PC98PictureType.graphic)
            {
                // Записываем в файл палитру
                bool isEvenColor = true;
                byte colorBuffer = 0;
                foreach (Color c in _palette)
                {
                    if (isEvenColor)
                    {
                        colorBuffer |= (byte)(c.R & 0xf0);
                        colorBuffer |= (byte)((c.G & 0xf0) >> 4);
                        stream.WriteByte(colorBuffer);
                        colorBuffer = 0;
                        colorBuffer |= (byte)(c.B & 0xf0);
                    }
                    else
                    {
                        colorBuffer |= (byte)((c.R & 0xf0) >> 4);
                        stream.WriteByte(colorBuffer);
                        colorBuffer = 0;
                        colorBuffer |= (byte)(c.G & 0xf0);
                        colorBuffer |= (byte)((c.B & 0xf0) >> 4);
                        stream.WriteByte(colorBuffer);
                        colorBuffer = 0;
                    }
                    isEvenColor = !isEvenColor;
                }
            }

            // Write bitmap here
            // Каким-то образом кодируем изображение в RLE
            switch (Type)
            {
                case PC98PictureType.graphic:
                    WriteBitmapCompressed(stream);
                    break;
                case PC98PictureType.text:
                    WriteBitmapStandart(stream);
                    break;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Невозможно сохранить изображение.\n" + ex.Message, "Ошибка!");
        }
    }

    /// <summary>
    /// Converts first <colorsToConvert>. Make sure there is less than <colorsToConvert> colors in the original image.
    /// </summary>
    /// <param name="image">Original image.</param>
    /// <param name="colorsToConvert">Maximum number of colors in palette.</param>
    /// <returns>Returns a palette according to PC-98 graphical capabilities.</returns>
    private static Color[] GetPC98Palette(Bitmap image, int colorsToConvert = 16)
    {
        Dictionary<Color, Color> palette = new Dictionary<Color, Color>();

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                if (palette.Count >= colorsToConvert)
                    goto breakOuterLoop;

                Color pixel = image.GetPixel(x, y);
                if (!palette.ContainsKey(pixel))
                {
                    int r = pixel.R & 0xf0;
                    int g = pixel.G & 0xf0;
                    int b = pixel.B & 0xf0;
                    r |= r >> 4;
                    g |= g >> 4;
                    b |= b >> 4;
                    palette.Add(pixel, Color.FromArgb(r, g, b));
                }
            }
        }

    breakOuterLoop:
        return palette.Values.ToArray();
    }

    private void WriteBitmapCompressed(Stream outputStream)
    {
        int imgPlaneSize = Width * Height;
        BitArray[] imagePlanes = new BitArray[4]
        {
            new BitArray(imgPlaneSize),
            new BitArray(imgPlaneSize),
            new BitArray(imgPlaneSize),
            new BitArray(imgPlaneSize)
        };

        // Заполняем 'плоскости' данными изображения
        int pixelIndex = 0;
        for (int y = 0; y < _convertedBitmap.Height; y++)
        {
            for (int x = 0; x < _convertedBitmap.Width; x++)
            {
                Color pixel = _convertedBitmap.GetPixel(x, y);
                int colorIndex = _palette.IndexOf(pixel);
                for (int i = 0; i < 4; i++)
                {
                    imagePlanes[i].Set(pixelIndex, (colorIndex & 0x01) != 0);
                    colorIndex >>= 1;
                }

                pixelIndex++;
            }
        }

        // Стараемся ужать каждую полученную 'плоскость'
        for (int i = 0; i < 4; i++)
        {
            BitArray plane = imagePlanes[i];
            bool prevBit = plane[0];
            int bitRunLength = 0;
            byte prevOctet = 0; // Октет (здесь) - это 7 бит изображения вместе с флагом неповторяемости
            int octetRunLength = 0; // Октет нужен здесь для более компактной записи областей с чередующимся цветом

            for (int j = 0; j < plane.Length; j++)
            {
                // Если сейчас не собираем октет
                if (octetRunLength == 0)
                {
                    // Если есть повторяющиеся биты
                    if (prevBit == plane[j] && bitRunLength < 63)
                    {
                        bitRunLength++;
                        // На всякий случай заполняем октет заранее, если вдруг длина повторений окажется меньше 7
                        prevOctet <<= 1;
                        prevOctet |= (byte)(prevBit ? 1 : 0);
                    }
                    else
                    {
                        // Если количество повторений меньше 7 (если все повторы могут поместиться в один октет)
                        if (bitRunLength < 7 && false) // False для отладки
                        {
                            // Начинаем собирать октет
                            prevBit = plane[j];

                            // После исправления все артефакт просто сдвинулись налево.
                            // Скорее всего, в DRAW_IMG тоже есть проблема.
                            octetRunLength = bitRunLength;
                            octetRunLength++;
                            prevOctet <<= 1;
                            prevOctet |= (byte)(prevBit ? 1 : 0);
                        }
                        else
                        {
                            // Пишем бит с количеством повторений
                            byte byteToWrite = (byte)(0b10000000 | ((prevBit ? 1 : 0) << 6) | bitRunLength);
                            outputStream.WriteByte(byteToWrite);
                        }
                        prevBit = plane[j];
                        bitRunLength = 1;
                    }
                }
                else
                {
                    if (octetRunLength >= 7)
                    {
                        // Пишем полученный октет в поток
                        outputStream.WriteByte((byte)(prevOctet & 0b01111111));
                        octetRunLength = 0;
                        bitRunLength = 1;
                    }
                    else
                    {
                        // Дописываем октет до 7 бит
                        octetRunLength++;
                        prevOctet <<= 1;
                        prevOctet |= (byte)(prevBit ? 1 : 0);
                    }
                    prevBit = plane[j];
                }
            }
            // Завершаем последнюю серию битов
            if (octetRunLength == 0)
            {
                // Пишем бит с количеством повторений
                byte byteToWrite = (byte)(0b10000000 | ((prevBit ? 1 : 0) << 6) | bitRunLength);
                outputStream.WriteByte(byteToWrite);
            }
            else
            {
                // Дополняем октет справа нулями
                prevOctet <<= 7 - octetRunLength;

                // Пишем полученный октет в поток
                outputStream.WriteByte((byte)(prevOctet & 0b01111111));
            }
        }
    }
    private void WriteBitmapStandart(Stream outputStream)
    {
        Color? prevPixel = _convertedBitmap.GetPixel(0, 0);
        int runLength = 0;
        byte len;
        byte col;
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (prevPixel == _convertedBitmap.GetPixel(x, y) && runLength < 15)
                    runLength++;
                else
                {
                    len = (byte)((runLength & 0x0f) << 4);
                    col = (byte)_palette.IndexOf(prevPixel);
                    outputStream.WriteByte((byte)(len | col));

                    prevPixel = _convertedBitmap.GetPixel(x, y);
                    runLength = 1;
                }
            }
        }
        len = (byte)((runLength & 0x0f) << 4);
        col = (byte)_palette.IndexOf(prevPixel);
        outputStream.WriteByte((byte)(len | col));
    }
}