using PGSem.ImageLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGSem.EdgeDetection
{
    public class SobelOperator
    {
        public static byte[,] SobelEdgeDetection(byte[,] image)
        {
            byte[,] edges = new byte[LoadImage.BYTES, LoadImage.BYTES];

            int[,] gx =
            {
                {-1, 0, 1 },
                {-2, 0, 2 },
                {-1, 0, 1 }
            };

            int[,] gy =
            {
                { -1, -2, -1 },
                { 0, 0, 0 },
                { 1, 2, 1 }
            };

            for (int x = 1; x < LoadImage.BYTES - 1; x++)
            {
                for (int y = 1; y < LoadImage.BYTES - 1; y++)
                {
                    int gradientX = 0;
                    int gradientY = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            gradientX += image[x + i, y + j] * gx[i + 1, j + 1];
                            gradientY += image[x + i, y + j] * gy[i + 1, j + 1];
                        }
                    }

                    int magnitude = (int)Math.Sqrt(gradientX * gradientX + gradientY * gradientY); //
                    edges[x, y] = (byte)Math.Min(magnitude, 255); // Normalize the result
                }
            }
            return edges;
        }
    }
}
