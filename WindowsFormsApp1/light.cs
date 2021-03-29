using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp1
{
    class light : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 35;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = sourceColor.R + k;
            int B = sourceColor.B + k;
            int G = sourceColor.G + k;
            Color resultColor = Color.FromArgb(Clamp(R, 0, 255), Clamp(G, 0, 255), Clamp(B, 0, 255));
            return resultColor;
        }
    }
}
