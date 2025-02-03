using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGSem.DrawInterface
{
    public interface IDrawable2DObject
    {
        void Draw(Graphics g);
        void Draw(Graphics g, List<byte[,]> images);
    }
}
