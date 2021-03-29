using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace WindowsFormsApp1
{
    class FOtrag : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            float R = 0, G = 0, B = 0;
            float Avg = 0;

            Color temp;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    temp = sourceImage.GetPixel(i, j);
                    R += temp.R; G += temp.G; B += temp.B;
                }
            R = (float)R / (sourceImage.Width * sourceImage.Height);
            G = (float)G / (sourceImage.Width * sourceImage.Height);
            B = (float)B / (sourceImage.Width * sourceImage.Height);
            Avg = (R + G + B) / 3;

            Color sourceColor, resultColor;

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    sourceColor = sourceImage.GetPixel(i, j);
                    resultColor = Color.FromArgb(Clamp((int)(sourceColor.R * Avg / R), 0, 255),
                                                Clamp((int)(sourceColor.G * Avg / G), 0, 255),
                                                  Clamp((int)(sourceColor.B * Avg / B), 0, 255));

                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            return resultImage;
        }
    }
}
