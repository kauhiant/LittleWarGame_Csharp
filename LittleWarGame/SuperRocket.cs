using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class SuperRocket : Warrior
    {
        public SuperRocket()
        {
            type = Warrior_Type.attacker;

            myStatus = Const.imageList[(int)WarriorList.Rocket];
            myRealStatus = myStatus[Const.Part.A];

            setBonus(25);
            setSpeed(50);
            setHP(100);
            setPower(1000);
            setAttackDistance(0);

            img.Image = myRealStatus[(int)Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }

        public override void attackTo(Warriors they)
        {
            if (they.size() == 0)
                return;

            if(they.size() == 1)
            {
                this.beKill();
            }
                

            if (this.distance(they.frontLine()) <= this.attackDistance)
            {
                for (int i = 0; i < they.size(); ++i)
                {
                    if (they.At(i) is Castle)
                        continue;

                    if (distance(they.At(i)) < 50)
                        they.At(i).beAttackFrom(this);
                }
                Const.Sound._attack.Play();
                    
                this.setBonus(0);
            }
        }

    }
}
