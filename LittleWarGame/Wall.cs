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

            this.shield = true;
            setBonus(15);
            setSpeed(2);
            setHP(1000);
            setPower(0);
            setAttackDistance(-1);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;

        }
        public override void moveTo(Point target)
        {
            if (this.distance(target) <= this.attackDistance || energy < 0)   //target in your attack range
                return;

            if (target.getValue() < this.value) //target in your left
            {
                this.value -= speed;
                this.energy -= this.speed;

                if (target.getValue() > this.value)
                    this.value = target.getValue();
            }
            else if (target.getValue() > this.value)    //target in your right
            {
                this.value += speed;
                this.energy -= this.speed;

                if (target.getValue() < this.value)
                    this.value = target.getValue();
            }
            
            changeStatusTo(Const.Status.move);
            myPictureBox.Left = value - leftFix;
            HP.fixPositionLeft(value - leftFix);
        }
    }
}
