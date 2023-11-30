using KGySoft.CoreLibraries;
using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Security;

namespace ImageReductor3
{
    public partial class Form1 : Form
    {
        private const string FILE_DIALOG_FILTER_STRING = "Изображения|*.png;*.jpg;*.jpeg;*.bmp";
        private const string SAVE_DIALOG_FILTER_STRING = "Изображение PC98|*.PIC";
        private Bitmap _sourceBitmap;
        private PC98Picture _outputPicture;

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = FILE_DIALOG_FILTER_STRING;
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;

            saveFileDialog1.Filter = SAVE_DIALOG_FILTER_STRING;
            saveFileDialog1.FileOk += SaveFileDialog1_FileOk;

            foreach (string name in Enum.GetNames<ScalingMode>())
                resizeMethodBox.Items.Add(name);
            resizeMethodBox.SelectedIndex = 0;

            quantizationMethodBox.Items.Add("Octree");
            quantizationMethodBox.Items.Add("Wu");
            quantizationMethodBox.Items.Add("Median cut");
            quantizationMethodBox.SelectedIndex = 1;

            ditheringMethodBox.Items.Add("Ordered");
            ditheringMethodBox.Items.Add("Random noise");
            ditheringMethodBox.Items.Add("Error diffusion");
            ditheringMethodBox.Items.Add("Interleaved gradient noise");
            ditheringMethodBox.SelectedIndex = 0;
        }

        private void OpenFileDialog1_FileOk(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Stream file = openFileDialog1.OpenFile();
                Bitmap image = new Bitmap(file);
                sourceImage.Image = image;
                file.Close();

                sourceImageSizeTextBox.Text = image.Width + "x" + image.Height;
                _sourceBitmap = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно открыть изображение.\n" + ex.Message, "Ошибка!");
            }
        }
        private void SaveFileDialog1_FileOk(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Stream file = saveFileDialog1.OpenFile();
                _outputPicture.WriteToStream(file);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно сохранить изображение.\n" + ex.Message, "Ошибка!");
            }
        }

        private void sourceImage_Click(object sender, EventArgs e)
        {
            Form fullImageForm = new FullImageForm(sourceImage.Image, InterpolationMode.Default);
            fullImageForm.Show();
        }
        private void outputImage_Click(object sender, EventArgs e)
        {
            Form fullImageForm = new FullImageForm(outputImage.Image, InterpolationMode.NearestNeighbor);
            fullImageForm.Show();
        }

        private void convertImageBtn_Click(object sender, EventArgs e)
        {
            if (_sourceBitmap != null)
                ConvertImage(_sourceBitmap);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void ConvertImage(Bitmap image)
        {
            try
            {
                PC98PictureType pictureType = graphicModeRadio.Checked ? PC98PictureType.graphic : PC98PictureType.text;
                Size size = new Size((int)imageWidthField.Value, (int)imageHeightField.Value);
                ScalingMode scalingMode = Enum.Parse<ScalingMode>(resizeMethodBox.SelectedIndex.ToString());
                bool keepAspectRatio = keepAspectRatioCheckBox.Checked;
                IQuantizer quantizer = GetCurrentQuantizer();
                IDitherer ditherer = GetCurrentDitherer(); // TODO: Дать возможность изменять сложные алгоритмы дизеринга

                PC98PictureConvertArgs convertArgs = new PC98PictureConvertArgs(pictureType, size, scalingMode, keepAspectRatio, quantizer, ditherer);

                _outputPicture = new PC98Picture(image, convertArgs);
                outputImage.Image = _outputPicture.GetBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно преобразовать изображение.\n" + ex.Message, "Ошибка!");
            }
        }
        private IQuantizer GetCurrentQuantizer(int colors = 16)
        {
            switch (quantizationMethodBox.SelectedIndex)
            {
                case 0:
                    return OptimizedPaletteQuantizer.Octree(colors);
                case 1:
                    return OptimizedPaletteQuantizer.Wu(colors);
                case 2:
                    return OptimizedPaletteQuantizer.MedianCut(colors);
                default:
                    return OptimizedPaletteQuantizer.Octree(colors);
            }
        }
        private IDitherer GetCurrentDitherer()
        {
            switch (ditheringMethodBox.SelectedIndex)
            {
                case 0:
                    // Изменять и этот параметр
                    return OrderedDitherer.Bayer4x4;
                case 1:
                    return new RandomNoiseDitherer();
                case 2:
                    // Изменять и этот параметр
                    return ErrorDiffusionDitherer.Sierra2;
                case 3:
                    return new InterleavedGradientNoiseDitherer();
                default:
                    return OrderedDitherer.Bayer4x4;
            }
        }
    }
}