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
            setSpeed(50);
            setHP(100);
            setPower(100);
            setAttackDistance(100);
            myPictureBox.Image = Image.FromFile(@"./Arrow.png");
        }
    }
}
