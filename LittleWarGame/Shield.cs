using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Shield:Warrior
    {
        public Shield()
        {
            type = Const.Warrior_Type.shielder;

            myStatus = Const.imageList[(int)Const.Warrior.Shield];
            myRealStatus = myStatus[Const.Part.A];
            
            setBonus(5);
            setSpeed(1);
            setHP(500);
            setPower(5);
            setAttackDistance(-1);

            img.Image = myRealStatus[(int)Const.Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }

        public override void beAttackFrom(Warrior other)
        {
            base.beAttackFrom(other);
            if(this.distance(other) == 0 && other.attackDistance > -1)
                other.beAttackFrom(this);
        }
    }
}
