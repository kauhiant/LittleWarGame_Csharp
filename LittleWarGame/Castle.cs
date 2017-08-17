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
            this.level = level;
            //setSpeed(0);
            setHP(500 * level);
            //setPower(0);
            //setAttackDistance(0);
            myPictureBox.Image = Image.FromFile(@"./castle.png");
            myPictureBox.Height = Const.castleHeight;
            myPictureBox.Top = Const.mainLineHeight - Const.castleHeight;
        }
    }
}
