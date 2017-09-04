using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class CoolDownTime
    {
        private DateTime last;
        private TimeSpan ts;
        private double cdTime;

        public CoolDownTime(double cd = 0)
        {
            cdTime = cd;
        }

        public void setCoolDownTime(double cd)
        {
            this.cdTime = cd;
        }

        public void record()
        {
            last = DateTime.Now;
        }

        public bool isCoolDown()
        {
            ts = DateTime.Now - last;
            return ts.TotalSeconds < cdTime;
        }

        public bool isNotCoolDown()
        {
            ts = DateTime.Now - last;
            return ts.TotalSeconds >= cdTime;
        }
    }
}
