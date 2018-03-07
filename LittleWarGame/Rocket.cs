using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rocket:Warrior
    {
        public Rocket(bool isMe)
        {
            type = Warrior_Type.attacker;

            myStatus = Const.imageList[(int)WarriorList.Rocket];
            myRealStatus = myStatus[Const.Part.A];
            if (isMe)
                setValueFrom(Program.playerData[4]);
            else
                setValueFrom(Program.AIData[4]);

            setBonus(25);

            img.Image = myRealStatus[(int)Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }

        public override void attackTo(Warriors they)
        {
            if (they.size() == 0)
                return;
            
            if(this.distance(they.frontLine()) <= 0)
            {
                for(int i=0; i<they.size(); ++i)
                {
                    if (distance(they.At(i)) < this.attackDistance)
                        they.At(i).beAttackFrom(this);
                }
                this.beKill();
                this.setBonus(0);
            }
        }

        public override void moveTo(Point target)
        {
            changeStatusTo((int)Status.move);

            if (this.distance(target) <= 0 || this.speed == 0)
                return;//if target in your attack range , you shouldn't move

            if (target.value < this.value) //target in your left
            {
                this.value -= speed;    //move to left

                if (target.value > this.value) //when you move too over to left of target
                    this.value = target.value;
            }
            else if (target.value > this.value)    //target in your right
            {
                this.value += speed;    //move to right

                if (target.value < this.value) //when you move too over to right of target
                    this.value = target.value;
            }

            //change your picture status and move it
            img.Left = value - leftFix;
            HP.fixPositionLeft(value - leftFix);
        }
    }
}
