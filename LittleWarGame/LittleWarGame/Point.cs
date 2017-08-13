using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Point
    {
        protected int value;

        public Point(int val=0)
        {
            if (val < 0) val = 0;
            value = val;
        }

        public int getValue()
        {
            return value;
        }

        public void setValue(int val)
        {
            if (val < 0)
                val = 0;
            value = val;
        }

        public int distance(Point other)
        {
            return Math.Abs(this.value - other.getValue());
        }
    }
}
