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
            type = Const.WarriorType.attacker;

            myStatus = Const.imageList[Const.Warrior.Sword];
            myRealStatus = myStatus[Const.Part.A];
            //setBonus(0);
            setSpeed(3);
            setHP(100);
            setPower(10);
            //setAttackDistance(0);

            CDTime.setCoolDownTime(1);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
