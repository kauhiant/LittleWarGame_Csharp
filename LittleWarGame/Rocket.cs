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
            type = Const.WarriorType.attacker;

            myStatus = Const.imageList[Const.Warrior.Rocket];
            myRealStatus = myStatus[Const.Part.A];
            setBonus(25);
            setSpeed(50);
            setHP(100);
            setPower(500);
            setAttackDistance(0);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
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
                this.bonus = 0;
            }
        }
    }
}
