using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class Sword:Warrior
    {
        public Sword()
        {
            type = Const.Warrior_Type.attacker;

            myStatus = Const.imageList[Const.Warrior.Sword];
            myRealStatus = myStatus[Const.Part.A];

            setBonus(1);
            setSpeed(3);
            setHP(100);
            setPower(10);
            //setAttackDistance(0);
            CDTime.setCoolDownTime(10);

            img.Image = myRealStatus[Const.Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
