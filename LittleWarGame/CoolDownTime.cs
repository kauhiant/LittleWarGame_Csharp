using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class CoolDownTime
    {
        private ulong last;
        private ulong ts;
        private uint cdTime;

        public CoolDownTime(uint cd = 0)
        {
            cdTime = cd;
        }

        public void setCoolDownTime(uint cd)
        {
            this.cdTime = cd;
        }

        public void record()
        {
            last = Const.gameTime.Value;
        }

        public bool isCoolDown()
        {
            ts = Const.gameTime.Value - last;
            return ts < cdTime;
        }

        public bool isNotCoolDown()
        {
            ts = Const.gameTime.Value - last;
            return ts >= cdTime;
        }
    }
}
