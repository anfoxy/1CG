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
    class closing : MorphOps
    {
        public override Bitmap  processImage(Bitmap sourceImage, BackgroundWorker worker)
        {

        
                Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
                Erosion er;
                Dilation di;
                for (int i = 0; i < sourceImage.Width; i++)
                {
                    worker.ReportProgress((int)((float)i / resultImage.Width * 100)); // будет 
                                                                                      // сигнализировать элементу BackgroundWorker о текущем прогрессе.
                    if (worker.CancellationPending)
                    {
                        return null;
                    }
                    for (int j = 0; j < sourceImage.Height; j++)
                    {
                    di = new Dilation();
                    resultImage.SetPixel(i, j, di.calculateNewPixelColor(sourceImage, i, j));
                    }
                }
            Bitmap resultImage2 = new Bitmap(resultImage.Width, resultImage.Height);
            for (int i = 0; i < resultImage2.Width; i++)
                {

                for (int j = 0; j < resultImage2.Height; j++)
                    {
                    er = new Erosion();

                    resultImage2.SetPixel(i, j, er.calculateNewPixelColor(resultImage, i, j));
                    }
                }
                return resultImage2;
            
        }

    }
}
