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
            type = Warrior_Type.shielder;

            myStatus = Const.imageList[(int)WarriorList.Castle];
            myRealStatus = myStatus[Const.Part.A];
            
            this.level = level;
            //setSpeed(0);
            setHP(1000 * level);
            //setPower(0);

            img.Image = myRealStatus[(int)Status.move];
          //  img.Height = Const.castleHeight;
            img.Top = Const.mainLineHeight - Const.castleHeight;
        }

        public override void moveTo(Point target)
        {
            
            if (this.HP.value < this.HP.maxValue*0.4)
            {
                if (this.HP.value > this.HP.maxValue * 0.3)
                    changeStatusTo(1);
                else if (this.HP.value > this.HP.maxValue * 0.2)
                    changeStatusTo(2);
                else if (this.HP.value > this.HP.maxValue * 0.1)
                    changeStatusTo(3);
                else
                    changeStatusTo(4);
            }
        }
    }
}
