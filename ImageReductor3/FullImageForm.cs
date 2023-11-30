using KGySoft.CoreLibraries;
using System.Drawing.Drawing2D;

namespace ImageReductor3
{
    public partial class FullImageForm : Form
    {
        public FullImageForm(Image image, InterpolationMode interpolation)
        {
            InitializeComponent();
            fullImage.Image = image;
            fullImage.InterpolationMode = interpolation;
        }
    }
}
