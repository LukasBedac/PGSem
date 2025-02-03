using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGSem
{
    public class DoubleBuffPanel : Panel
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public DoubleBuffPanel()
        {
            //Used from teacher's project
            SetStyle(ControlStyles.AllPaintingInWmPaint | //Do not erase the background, reduce flicker
                 ControlStyles.OptimizedDoubleBuffer | //Double buffering
                 ControlStyles.UserPaint, //Use a custom redraw event to reduce flicker
                 true);

            Width = this.ClientSize.Width;
            Height = this.ClientSize.Height;
        }
    }
}
