using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

public class AlphaPictureBox : PictureBox
{
    private float imageOpacity = 1.0f;

    public float ImageOpacity
    {
        get { return imageOpacity; }
        set
        {
            if (value >= 0 && value <= 1)
            {
                imageOpacity = value;
                Invalidate(); // Force the control to repaint
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Image != null)
        {
            using (ImageAttributes attributes = new ImageAttributes())
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = imageOpacity; // Set the opacity

                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                Rectangle rect = new Rectangle(0, 0, Width, Height);
                e.Graphics.DrawImage(Image, rect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, attributes);
            }
        }
        else
        {
            base.OnPaint(e); // If no image, do default painting
        }
    }
}
