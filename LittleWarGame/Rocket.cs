using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rocket:Warrior
    {
        public Rocket()
        {
            type = Const.Warrior_Type.attacker;

            myStatus = Const.imageList[(int)Const.Warrior.Rocket];
            myRealStatus = myStatus[Const.Part.A];

            setBonus(25);
            setSpeed(50);
            setHP(100);
            setPower(1000);
            setAttackDistance(0);

            img.Image = myRealStatus[Const.Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }

        public override void attackTo(Warriors they)
        {
            if (they.size() == 0)
                return;
            
            if(this.distance(they.frontLine()) <= this.attackDistance)
            {
                for(int i=0; i<they.size(); ++i)
                {
                    if (distance(they.At(i)) < 50)
                        they.At(i).beAttackFrom(this);
                }
                Const.Sound._attack.Play();
                this.beKill();
                this.setBonus(0);
            }
        }
    }
}
