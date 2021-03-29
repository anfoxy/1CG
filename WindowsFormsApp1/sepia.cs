using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class sepia : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k =35;
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intesiv = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;
            int R = (int)(intesiv + 2*k);
            int B = (int)(intesiv - 1 * k);
            int G = (int)(intesiv + 0.5 * k);
            Color resultColor = Color.FromArgb(Clamp(R,0,255), Clamp(G, 0, 255), Clamp(B, 0, 255));
            return resultColor;
        }
    }
}
