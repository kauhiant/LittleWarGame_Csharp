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
            type = Const.Warrior_Type.helper;

            myStatus = Const.imageList[(int)Const.Warrior.Rescue];
            myRealStatus = myStatus[Const.Part.A];
            //setBonus(0);
            setSpeed(3);
            setHP(100);
            setPower(0);
            setAttackDistance(-1);

            CDTime.setCoolDownTime(15);

            img.Image = myRealStatus[(int)Const.Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
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
