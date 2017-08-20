using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rocket:Warrior
    {
        public Rocket(){
            myStatus = Const.imageList[Const.Warrior.Rocket];
            myRealStatus = myStatus[Const.Part.A];
            setSpeed(50);
            setHP(100);
            setPower(500);
            setAttackDistance(0);
            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }

        public override void attackTo(List<Warrior> group)
        {
            if (group.Count == 0)
                return;

            bool isBoom = false;
            for(int i =0; i<group.Count; ++i)
            {
                if (this.distance(group[i]) <= this.getAttackDistance())
                {
                    myPictureBox.Image = myRealStatus[Const.Status.attack];
                    group[i].beAttackFrom(this);
                    isBoom = true;
                }
            }
            if(isBoom)
                this.beKill();
        }
    }
}
