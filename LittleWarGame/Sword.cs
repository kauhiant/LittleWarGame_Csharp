using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Sword:Warrior
    {
        public Sword()
        {
            setSpeed(10);
            setHP(100);
            setPower(10);
            //setAttackDistance(0);
        }
    }
}
