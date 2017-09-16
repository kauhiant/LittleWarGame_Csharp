using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Point
    {
        private int _value;

        public int value
        {
            get { return _value; }
            set { if (value < 0) value = 0; _value = value; }
        }

        public Point(int val=0) 
        {
            if (val < 0) val = 0;
            _value = val;
        }

        


        public int distance(Point other)
        {   return Math.Abs(this._value - other._value); }

        public bool inRange(Point a,Point b)
        {
            int aValue = a._value;
            int bValue = b._value;
            if(aValue > bValue)
            {
                int tmp = aValue;
                aValue = bValue;
                bValue = tmp;
            }

            return (this._value >= aValue && this._value <= bValue);
        }

        public void fixInRange(Point first , Point second)
        {
            if (this.inRange(first, second)) return;

            this._value = first._value;
        }

        public int chooseCloserFrom(Point A , Point B)
        {
            if (this.distance(A) > this.distance(B))
                return B._value;
            else
                return A._value;
        }
    }
}
