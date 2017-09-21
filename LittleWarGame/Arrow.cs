using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class Arrow:Warrior
    {
        public Arrow()
        {
            type = Const.Warrior_Type.attacker;

            myStatus = Const.imageList[Const.Warrior.Arrow];
            myRealStatus = myStatus[Const.Part.A];

            setBonus(5);
            setSpeed(1);
            setHP(50);
            setPower(10);
            setAttackDistance(100);
            CDTime.setCoolDownTime(15);

            img.Image = myRealStatus[Const.Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
