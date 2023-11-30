using System.Drawing.Drawing2D;
using System.Windows.Forms;

/// <summary>
/// Inherits from PictureBox; adds Interpolation Mode Setting
/// </summary>

namespace ImageReductor3;
public class InterpolPictureBox : PictureBox
{
    public InterpolationMode InterpolationMode { get; set; }

    protected override void OnPaint(PaintEventArgs paintEventArgs)
    {
        paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
        base.OnPaint(paintEventArgs);
    }
}