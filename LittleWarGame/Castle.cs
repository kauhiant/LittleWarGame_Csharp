using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class Castle:Warrior
    {
        private int level;

        public Castle(int level)
        {
            myStatus = Const.imageList[Const.Warrior.Castle];
            myRealStatus = myStatus[Const.Part.A];

            this.level = level;
            //setSpeed(0);
            setHP(500 * level);
            //setPower(0);
            setAttackDistance(-1);//can't attack

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Height = Const.castleHeight;
            myPictureBox.Top = Const.mainLineHeight - Const.castleHeight;
        }
    }
}
