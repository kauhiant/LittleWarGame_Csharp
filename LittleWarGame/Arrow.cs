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
            myStatus = Const.imageList[Const.Warrior.Arrow];
            myRealStatus = myStatus[Const.Part.A];
            setBonus(5);
            setSpeed(5);
            setHP(50);
            setPower(10);
            setAttackDistance(100);
            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
