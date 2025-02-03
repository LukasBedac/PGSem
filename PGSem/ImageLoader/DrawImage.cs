using PGSem.DrawInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGSem.ImageLoader
{
    public class DrawImage : IDrawable2DObject
    {
        public void Draw(Graphics g)
        {
            if (LoadImage.ShowImage && LoadImage.bitMapImage != null)
            {
                g.DrawImage(LoadImage.bitMapImage, 0, 0);
            }
        }

        public void Draw(Graphics g, List<byte[,]> images)
        {
            if (images.Count > 0)
            {
                int count = 0;
                int offsetX = 0;
                foreach (byte[,] image in images)
                {
                    Bitmap convertedImage = LoadImage.ToBitMap(image, LoadImage.BYTES);
                    g.DrawImage(convertedImage, 0 + offsetX, 0 );
                    offsetX += 512;
                    count++;
                    if (count % 4 == 0)
                    {
                        offsetX = 0;
                    }
                }
            }
        }
    }
}
