using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rocket:Warrior
    {
        public Rocket(){
            myStatus = Const.imageList[Const.Warrior.Rocket];
            myRealStatus = myStatus[Const.Part.A];
            setSpeed(50);
            setHP(500);
            setPower(500);
            setAttackDistance(0);
            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
