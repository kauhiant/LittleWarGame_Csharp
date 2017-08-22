using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Hatchet:Warrior
    {
        public Hatchet()
        {
            myStatus = Const.imageList[Const.Warrior.Sword];
            myRealStatus = myStatus[Const.Part.A];

            setSpeed(8);
            setHP(200);
            setPower(50);
            //setAttackDistance(0);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void attackTo(List<Warrior> group)
        {
            if (group.Count == 0)
                return;
            
            for (int i = 0; i < group.Count; ++i)
            {
                if (this.distance(group[i]) <= this.getAttackDistance())
                {
                    myPictureBox.Image = myRealStatus[Const.Status.attack];
                    group[i].beAttackFrom(this);
                }
            }
        }
    }
}
