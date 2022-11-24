using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.NullableExamples
{
    internal struct Point
    {
        public double X;
        public double Y;
        public Point() : this(0, 0)
        {

        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
