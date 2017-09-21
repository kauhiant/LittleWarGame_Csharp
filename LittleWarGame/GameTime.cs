using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class GameTime
    {
        private ulong value;
        private uint div;
        private uint tmpClock;

        public GameTime(uint div = 1)
        {
            this.div = div;
            value = 0;
            tmpClock = 0;
        }
        public ulong Value{ get { return value; } }
        public void clock()
        {
            ++tmpClock;
            if(tmpClock == div)
            {
                tmpClock = 0;
                ++value;
            }
        }
    }
}
