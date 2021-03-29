﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Dilation : MorphOps
    {
        
        public override  Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float maxR = 0f;
            float maxG = 0f;
            float maxB = 0f;
            Color sourceColor;
            int ht = kernel.GetLength(1);
            int wh = kernel.GetLength(0);
            for (int k = -(ht / 2); k <= (ht / 2); ++k)
            {
                for (int l = -(wh / 2); l <= (wh / 2); ++l)
                {
                    int idx = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idy = Clamp(y + l, 0, sourceImage.Height - 1);
                    if (kernel[(wh / 2) + l, (ht / 2) + k] != 0f)
                    {
                        sourceColor = sourceImage.GetPixel(idx, idy);
                        if ((sourceColor.R > maxR))
                        {
                            maxR = sourceColor.R;
                        }
                        if ((sourceColor.G > maxG))
                        {
                            maxG = sourceColor.G;
                        }
                        if ((sourceColor.B > maxB))
                        {
                            maxB = sourceColor.B;
                        }
                    }
                }
            }
            Color resultColor = Color.FromArgb(Clamp((int)maxR, 0, 255), Clamp((int)maxG, 0, 255), Clamp((int)maxB, 0, 255));
            return resultColor;

        }

       
    };
}


