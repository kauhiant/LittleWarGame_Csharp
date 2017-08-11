using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Arrow:Warrior
    {
        public Arrow()
        {
            setSpeed(5);
            setHP(100);
            setPower(10);
            setAttackDistance(100);
        }
    }
}
