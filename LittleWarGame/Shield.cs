using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Shield:Warrior
    {
        public Shield()
        {
            myStatus = Const.imageList[Const.Warrior.Shield];
            myRealStatus = myStatus[Const.Part.A];
            setSpeed(8);
            setHP(500);
            setPower(0);
            setAttackDistance(-1);
            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
