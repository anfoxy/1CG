using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Rezk : MatrixFilter
    {
        public Rezk()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        kernel[i, j] = 9.0f;
                    }
                    else
                        kernel[i, j] = -1.0f;
                }
        }
    }
}
