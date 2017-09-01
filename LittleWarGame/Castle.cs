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
            type = Const.WarriorType.shielder;

            myStatus = Const.imageList[Const.Warrior.Castle];
            myRealStatus = myStatus[Const.Part.A];

            this.shield = true;
            this.level = level;
            //setSpeed(0);
            setHP(1000 * level);
            //setPower(0);
            setAttackDistance(-1);//can't attack

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Height = Const.castleHeight;
            myPictureBox.Top = Const.mainLineHeight - Const.castleHeight;
        }

        public override void beAttackFrom(Warrior other)
        {
            base.beAttackFrom(other);
            if (this.getHP() < 800)
            {
                if (this.getHP() > 600)
                    changeStatusTo(1);
                else if (this.getHP() > 400)
                    changeStatusTo(2);
                else if (this.getHP() > 200)
                    changeStatusTo(3);
                else
                    changeStatusTo(4);
            }
        }
    }
}
