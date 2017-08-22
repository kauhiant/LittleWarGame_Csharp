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
            myStatus = Const.imageList[Const.Warrior.Shield];
            myRealStatus = myStatus[Const.Part.A];

            setSpeed(10);
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
                myPictureBox.Image = myRealStatus[Const.Status.move];
                this.value -= speed;
                this.energy -= this.speed;

                if (target.getValue() > this.value)
                    this.value = target.getValue();
            }
            else if (target.getValue() > this.value)    //target in your right
            {
                myPictureBox.Image = myRealStatus[Const.Status.move];
                this.value += speed;
                this.energy -= this.speed;

                if (target.getValue() < this.value)
                    this.value = target.getValue();
            }

            myPictureBox.Left = value - leftFix;
        }
    }
}
