using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp1
{
    class Perenos : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x + 50 < sourceImage.Width)
            {
                Color sourceColor = sourceImage.GetPixel(x + 50, y);
                Color resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                    Clamp(sourceColor.G, 0, 255),
                   Clamp(sourceColor.B, 0, 255));
                return resultColor;
            }
            else
            {
                Color resultColor = Color.FromArgb(0,0,0);
                return resultColor;
            }

        }
    }
}
