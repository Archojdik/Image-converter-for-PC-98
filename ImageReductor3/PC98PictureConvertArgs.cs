using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageReductor3
{
    internal readonly struct PC98PictureConvertArgs
    {
        public readonly PC98PictureType Type;
        public readonly Size Size;
        public readonly ScalingMode ScalingMode;
        public readonly bool KeepAspectRatio;
        public readonly IQuantizer Quantizer;
        public readonly IDitherer Ditherer;

        public PC98PictureConvertArgs(PC98PictureType type, Size size, ScalingMode scalingMode, bool keepAspectRatio, IQuantizer quantizer, IDitherer ditherer)
        {
            Type = type;
            Size = size;
            ScalingMode = scalingMode;
            KeepAspectRatio = keepAspectRatio;
            Quantizer = quantizer;
            Ditherer = ditherer;
        }
    }
}
