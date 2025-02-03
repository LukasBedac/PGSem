using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PGSem.ImageLoader
{
    public class LoadImage
    {
        public const int BYTES = 512;  
        public static byte[,]? loadedImage = null;
        public static Bitmap? bitMapImage = null;
        public static string filePath = "";
        public static bool ShowImage { get; set; }

        public LoadImage(string path) 
        {
            LoadLuminence(path);
        }

        private void LoadLuminence(string path)
        {
            loadedImage = new byte[BYTES, BYTES];
            filePath = path;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[BYTES * BYTES];
                stream.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < BYTES; i++)
                {
                    for (int j = 0; j < BYTES; j++)
                    {
                        loadedImage[i,j] = buffer[BYTES * i + j];
                    }
                }
                stream.Close();
            }
            bitMapImage = ToBitMap(loadedImage, BYTES);
        }
        public static Bitmap ToBitMap(byte[,] image, int resolution)
        {
            Bitmap bitmap = new Bitmap(resolution, resolution, PixelFormat.Format24bppRgb);
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, resolution, resolution), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            int stride = bmpData.Stride;
            IntPtr ptr = bmpData.Scan0;
            byte[] rgbData = new byte[stride * resolution];

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    byte luminance = image[y, x]; // Get Y value
                    int pos = y * stride + x * 3; // 3 bytes per pixel (RGB)

                    rgbData[pos] = luminance;    // Blue
                    rgbData[pos + 1] = luminance; // Green
                    rgbData[pos + 2] = luminance; // Red
                }
            }

            Marshal.Copy(rgbData, 0, ptr, rgbData.Length);
            bitmap.UnlockBits(bmpData);

            return bitmap;
        }
    }
}
