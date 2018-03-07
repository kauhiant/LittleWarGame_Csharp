using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Hatchet:Warrior
    {
        public Hatchet(bool isMe)
        {
            type = Warrior_Type.attacker;

            myStatus = Const.imageList[(int)WarriorList.Hatchet];
            myRealStatus = myStatus[Const.Part.A];
            if (isMe)
                setValueFrom(Program.playerData[3]);
            else
                setValueFrom(Program.AIData[3]);

            setBonus(10);
            CDTime.setCoolDownTime(15);

            img.Image = myRealStatus[(int)Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void attackTo(Warriors they)
        {
            if (CDTime.isCoolDown() || they.size() == 0)
                return;

            if (this.distance(they.frontLine()) <= this.attackDistance)
            {
                img.Image = myRealStatus[(int)Status.attack];
                attackGroup(they.frontGroup());
                CDTime.record();
            }
        }
        private void attackGroup(List<Warrior> group)
        {
            foreach(Warrior each in group)
            {
                each.beAttackFrom(this);
                if (each.isShielder()) break;
            }
        }
    }
}
