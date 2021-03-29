using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Voln : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int nx = Clamp((x + (int)(20 * Math.Sin(2 * Math.PI * y / 60)) * 4), 0, sourceImage.Width - 4);
            Color sourceColor = sourceImage.GetPixel(nx, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                Clamp(sourceColor.G, 0, 255),
               Clamp(sourceColor.B, 0, 255));
            return resultColor;
        }
    }
}
