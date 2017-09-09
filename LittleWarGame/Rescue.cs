using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rescue:Warrior
    {
        public Rescue()
        {
            type = Const.WarriorType.helper;

            myStatus = Const.imageList[Const.Warrior.Rescue];
            myRealStatus = myStatus[Const.Part.A];
            //setBonus(0);
            setSpeed(3);
            setHP(100);
            setPower(0);
            setAttackDistance(-1);

            CDTime.setCoolDownTime(1.5);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void helpTo(Warriors we)
        {
            if (CDTime.isCoolDown()) return;

            Warrior target = this;
            int min = 50;

            for(int i=we.size()-1; i>=0; --i)
            {
                if (we.At(i) is Rescue) continue;
                if(this.distance(we.At(i)) <= min)
                {
                    min = this.distance(we.At(i));
                    target = we.At(i);
                }
            }

            target.addHP(20);
            CDTime.record();
        }
    }
}
