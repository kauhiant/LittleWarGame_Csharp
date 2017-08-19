using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class Warrior:Point
    {
        protected List<List<Image>> myStatus;
        protected List<Image> myRealStatus;

        protected int speed;
        protected int HP;
        protected int power;
        protected int attackDistance;

        protected int leftFix = Const.pictureWidth;
        
        public System.Windows.Forms.Form mainForm;
        public System.Windows.Forms.PictureBox myPictureBox;

        public Warrior()
        {
            this.speed = 0;
            this.HP = 0;
            this.power = 0;
            this.attackDistance = 0;

            //just creat a picturebox not add to mainForm
            this.myPictureBox = new System.Windows.Forms.PictureBox();
        }

        public int getSpeed() { return speed; }
        public int getHP() { return HP; }
        public int getPower() { return power; }
        public int getAttackDistance() { return attackDistance; }

        protected void setSpeed(int val)
        {
            if (val < 0) val = 0;
            speed = val;
        }

        protected void setHP(int val)
        {
            if (val < 0) val = 0;
            HP = val;
        }

        protected void setPower(int val)
        {
            if (val < 0) val = 0;
            power = val;
        }

        protected void setAttackDistance(int val)
        {
            if (val < -1) val = -1;
            attackDistance = val;
        }

        public void moveTo(Point target)
        {
            if (this.distance(target) <= this.attackDistance)   //target in your attack range
                return;
            
            if (target.getValue() < this.value) //target in your left
            {
                myPictureBox.Image = myRealStatus[Const.Status.move];
                this.value -= speed;

                if (target.getValue() > this.value)
                    this.value = target.getValue();
            }
            else if (target.getValue() > this.value)    //target in your right
            {
                myPictureBox.Image = myRealStatus[Const.Status.move];
                this.value += speed;

                if (target.getValue() < this.value)
                    this.value = target.getValue();
            }

            myPictureBox.Left = value - leftFix;
        }

        public void beKill()
        {
            HP = 0;
            power = 0;
            attackDistance = 0;
            speed = 0;
            try
            {
                mainForm.Controls.Remove(myPictureBox);
            }
            catch (Exception )
            {
                mainForm.Text = "have error when remove picturebox";
            }
        }

        public void beAttack(int harm)
        {
            HP -= harm;
            if (HP <= 0) 
                this.beKill();
        }

        public void attack(Warrior obj)
        {
            if (this.distance(obj) <= this.attackDistance)
            {
                myPictureBox.Image = myRealStatus[Const.Status.attack];
                obj.beAttack(this.power);
            }
        }
        
        public void addPictureBoxTo(System.Windows.Forms.Form mainForm)
        {
            myPictureBox.Width = Const.pictureWidth;
            myPictureBox.BackColor = Color.Transparent;
            myPictureBox.Left = value - leftFix;

            this.mainForm = mainForm;
            this.mainForm.Controls.Add(myPictureBox);
        }

        public void setPictureBoxTop(int y)
        {
            myPictureBox.Top = y;
        }

        public void setReverse()
        {
            if (leftFix == Const.pictureWidth)
            {
                leftFix = 0;
                myRealStatus = myStatus[Const.Part.B];
            }
            else
            {
                leftFix = Const.pictureWidth;
                myRealStatus = myStatus[Const.Part.A];
            }
        }
        
        public void changeStatus(Image img)
        {
            myPictureBox.Image = img;
        }
    }
}
