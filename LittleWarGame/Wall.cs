using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Wall:Warrior
    {
        private int energy;
        public Wall(bool isMe)
        {
            type = Warrior_Type.shielder;

            myStatus = Const.imageList[(int)WarriorList.Wall];
            myRealStatus = myStatus[Const.Part.A];
            if (isMe)
                setValueFrom(Program.playerData[5]);
            else
                setValueFrom(Program.AIData[5]);

            setBonus(15);
            energy = this.attackDistance;

            img.Image = myRealStatus[(int)Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;

        }
        public override void moveTo(Point target)
        {
            if (this.distance(target) <= 0 || energy <= 0)   //target in your attack range
                return;

            if (target.value < this.value) //target in your left
            {
                this.value -= speed;
                this.energy -= this.speed;

                if (target.value > this.value)
                    this.value = target.value;
            }
            else if (target.value > this.value)    //target in your right
            {
                this.value += speed;
                this.energy -= this.speed;

                if (target.value < this.value)
                    this.value = target.value;
            }
            
            changeStatusTo((int)Status.move);
            img.Left = value - leftFix;
            HP.fixPositionLeft(value - leftFix);
        }
    }
}
