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
        {   return value;   }

        public void setValue(int val)
        {
            if (val < 0) val = 0;
            value = val;
        }

        public int distance(Point other)
        {   return Math.Abs(this.value - other.getValue()); }

        public bool inRange(Point a,Point b)
        {
            int aValue = a.getValue();
            int bValue = b.getValue();
            if(aValue > bValue)
            {
                int tmp = aValue;
                aValue = bValue;
                bValue = tmp;
            }

            return (this.value >= aValue && this.value <= bValue);
        }

        public void fixInRange(Point first , Point second)
        {
            if (this.inRange(first, second)) return;

            this.value = first.getValue();
        }
    }
}
