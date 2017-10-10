using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Shield:Warrior
    {
        public Shield(bool isMe)
        {
            type = Warrior_Type.shielder;

            myStatus = Const.imageList[(int)WarriorList.Shield];
            myRealStatus = myStatus[Const.Part.A];
            if (isMe)
                setValueFrom(Program.playerData[2]);
            else
                setValueFrom(Program.AIData[2]);

            setBonus(5);

            img.Image = myRealStatus[(int)Status.move];
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
