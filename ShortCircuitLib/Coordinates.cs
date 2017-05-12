using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortCircuitLib
{
    public class Coordinates2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates2D()
        {
            X = 0;
            Y = 0;
        }
        public Coordinates2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
