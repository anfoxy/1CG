using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    class HistogramsFilter : Filters
    {
        int minR, minG, minB, maxR, maxG, maxB;
        public void get_min_max(Bitmap sourseImage)
        {
            minR = 255; minG = 255; minB = 255; maxR = 0; maxG = 0; maxB = 0;
            Color dop;
            for (int i = 0; i < sourseImage.Width; i++)
            {
                for (int j = 0; j < sourseImage.Height; j++)
                {
                    dop = sourseImage.GetPixel(i, j);
                    if (minR > dop.R)
                        minR = dop.R;
                    if (minG > dop.G) minG = dop.G;
                    if (minB > dop.B) minB = dop.B;

                    if (maxR < dop.R) maxR = dop.R;
                    if (maxG < dop.G) maxG = dop.G;
                    if (maxB < dop.B) maxB = dop.B;
                }
            }
        }
        public override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            Color sourseColor = sourseImage.GetPixel(x, y);
            if (x == 0 && y == 0)
                get_min_max(sourseImage);
            int nowR = sourseColor.R, nowG = sourseColor.G, nowB = sourseColor.G;

            if ((nowR - minR != 0) && (maxR - minR != 0)) nowR = (nowR - minR) * (255 / (maxR - minR));
            if (nowR < sourseColor.R) nowR = sourseColor.R;
            if ((nowG - minG != 0) && (maxG - minG != 0))
                nowG = (nowG - minG) * (255 / (maxG - minG));
            if (nowG < sourseColor.G) nowG = sourseColor.G;
            if ((nowB - minB != 0) && (maxB - minB != 0))
                nowB = (nowB - minB) * (255 / (maxB - minB));
            if (nowB < sourseColor.B)
                nowB = sourseColor.B;

            Color resultColor = Color.FromArgb(nowR, nowG, nowB);
            return resultColor;

        }
    }
}