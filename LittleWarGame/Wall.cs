using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Wall:Warrior
    {
        private int energy = 100;
        public Wall()
        {
            type = Const.WarriorType.shielder;

            myStatus = Const.imageList[Const.Warrior.Wall];
            myRealStatus = myStatus[Const.Part.A];
            
            setBonus(15);
            setSpeed(2);
            setHP(2000);
            setPower(0);
            setAttackDistance(-1);

            img.Image = myRealStatus[Const.Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;

        }
        public override void moveTo(Point target)
        {
            if (this.distance(target) <= this.attackDistance || energy < 0)   //target in your attack range
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
            
            changeStatusTo(Const.Status.move);
            img.Left = value - leftFix;
            HP.fixPositionLeft(value - leftFix);
        }
    }
}
