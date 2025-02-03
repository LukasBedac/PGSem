using PGSem.ImageLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGSem.HelpAlgorithms
{
    public class GaussFilter
    {
        public const int KERNELSIZE = 5; // Kernel = gaussovo jadro
        public const double SIGMA = 0.5;

        private static double[,] GenerateGaussKernel() //Gauss kernel matrix for smoothing
        {
            // Gauss function
            //G(x,y) = 1/(2*PI*Sigma^2) * e^-((x^2 + y^2)/(2*Sigma^2))

            double[,] kernel = new double[KERNELSIZE, KERNELSIZE];
            int kernelCenter = KERNELSIZE / 2;
            double sum = 0; //Normalizing kernel values

            for (int x = -kernelCenter; x <= kernelCenter; x++)
            {
                for (int y = -kernelCenter; y <= kernelCenter; y++)
                {
                    kernel[x + kernelCenter, y + kernelCenter] =
                        1 / (2 * Math.PI * SIGMA * SIGMA) * Math.Exp(-(x * x + y * y) / (2 * SIGMA * SIGMA));
                    sum += kernel[x + kernelCenter, y + kernelCenter];
                }
            }

            for (int x = 0; x < KERNELSIZE; x++)
            {
                for (int y = 0; y < KERNELSIZE; y++)
                {
                    kernel[x, y] /= sum;
                }
            }
            return kernel;
        }

        public static byte[,] ApplyGaussFilter(byte[,] image)
        {
            byte[,] resultImage = new byte[LoadImage.BYTES, LoadImage.BYTES];
            double[,] kernel = GenerateGaussKernel();

            //Convolution - applying kernel to the image for smoothening
            for (int x = KERNELSIZE / 2; x < LoadImage.BYTES - KERNELSIZE / 2; x++)
            {
                for (int y = KERNELSIZE / 2; y < LoadImage.BYTES - KERNELSIZE / 2; y++)
                {
                    double sum = 0;
                    for (int i = -KERNELSIZE / 2; i <= KERNELSIZE / 2; i++)
                    {
                        for (int j = -KERNELSIZE / 2; j <= KERNELSIZE / 2; j++)
                        {
                            sum += image[x + i, y + j] * kernel[i + KERNELSIZE / 2, j + KERNELSIZE / 2];
                        }
                    }
                    // Obmedzenie do validneho rozsahu
                    resultImage[x, y] = (byte)Math.Min(Math.Max(sum, 0), 255);
                }
            }
            return resultImage;
        }
    }
}
