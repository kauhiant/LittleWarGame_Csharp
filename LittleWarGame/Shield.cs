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
            myStatus = Const.imageList[Const.Warrior.Shield];
            myRealStatus = myStatus[Const.Part.A];

            this.shield = true;
            setBonus(5);
            setSpeed(6);
            setHP(500);
            setPower(5);
            setAttackDistance(-1);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }

        public override void beAttackFrom(Warrior other)
        {
            base.beAttackFrom(other);
            if(this.distance(other) == 0 && other.getAttackDistance() > -1)
                other.beAttackFrom(this);
        }
    }
}
