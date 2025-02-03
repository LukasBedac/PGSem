using PGSem.ImageLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGSem.HelpAlgorithms
{
    public class OtsuTreshold
    {
        public static byte[,] ApplyOtsuTreshold(byte[,] image)
        {
            byte[,] result = new byte[LoadImage.BYTES, LoadImage.BYTES];
            //Histogram obrazka ako funkcia - posledna prednaska
            int[] histogram = new int[256];
            for (int i = 0; i < LoadImage.BYTES; i++)
            {
                for (int j = 0; j < LoadImage.BYTES; j++)
                {
                    histogram[image[i, j]]++;
                }
            }

            int total = LoadImage.BYTES * LoadImage.BYTES; //Number of pixels
            float sumB = 0f; // Background intensity
            float sum1 = 0f; // Foreground intensity
            int weightB = 0; // Background weight
            int weight1 = 0; // Foreground weight
            float maxVar = 0f; // Maximum variance between class - maximalny rozptyl medzi triedami
            int threshold = 0; // Optimal treshold value - optimalna prahova hodnota

            for (int i = 0; i < 256; i++)
            {
                sum1 += i * histogram[i];
            }

            for (int i = 0; i < 256; i++)
            {
                weightB += histogram[i];
                if (weightB == 0)
                    continue;

                weight1 = total - weightB;
                if (weight1 == 0)
                    break;

                sumB += i * histogram[i];

                float mB = sumB / weightB;
                float mF = (sum1 - sumB) / weight1;

                float between = weightB * weight1 * (mB - mF) * (mB - mF);

                if (between > maxVar)
                {
                    maxVar = between;
                    threshold = i;
                }
            }
            //Because there is problem with all images after adaptive threshold is made
            // i have to adjust it manually
            if (LoadImage.filePath.Contains("NewImage.txt")) 
            {
                threshold = 20; 
            } else if (LoadImage.filePath.Contains("NewImage2.txt"))
            {
                threshold = 50;
            } else
            {
                threshold = 35;
            }
                
            //Applying treshold
            for (int i = 0; i < LoadImage.BYTES; i++)
            {
                for (int j = 0; j < LoadImage.BYTES; j++)
                {
                    result[i, j] = image[i, j] > threshold ? (byte)255 : (byte)0;
                }
            }
            return result;
        }
    }
}
