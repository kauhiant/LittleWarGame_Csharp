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
            setSpeed(10);
            setHP(100);
            setPower(10);
            //setAttackDistance(0);
            myPictureBox.Image = Image.FromFile(@"./Sword.png");
        }
    }
}
