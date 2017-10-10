using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rescue:Warrior
    {
        public Rescue(bool isMe)
        {
            type = Warrior_Type.helper;

            myStatus = Const.imageList[(int)WarriorList.Rescue];
            myRealStatus = myStatus[Const.Part.A];
            if (isMe)
                setValueFrom(Program.playerData[6]);
            else
                setValueFrom(Program.AIData[6]);

            CDTime.setCoolDownTime(15);

            img.Image = myRealStatus[(int)Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void helpTo(Warriors we)
        {
            if (CDTime.isCoolDown()) return;

            Warrior target = this;
            int min = this.attackDistance;

            for(int i=we.size()-1; i>=0; --i)
            {
                if (we.At(i) is Rescue) continue;
                if (we.At(i).fullHP()) continue;
                if(this.distance(we.At(i)) <= min)
                {
                    min = this.distance(we.At(i));
                    target = we.At(i);
                }
            }

            target.addHP(this.power);
            CDTime.record();
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
