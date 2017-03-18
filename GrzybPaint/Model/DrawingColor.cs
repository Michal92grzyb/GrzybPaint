using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrzybPaint.Model
{
    public class DrawingColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public DrawingColor(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
