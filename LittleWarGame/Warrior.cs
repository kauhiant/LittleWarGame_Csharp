using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace LittleWarGame
{
    class Warrior:Point
    {
        protected List<List<Image>> myStatus;
        protected List<Image> myRealStatus;

        protected int speed;
        protected int power;
        protected int attackDistance;
        
        protected System.Windows.Forms.Form mainForm;

        protected int leftFix = Const.pictureWidth;
        protected ValueBar HP;
        protected System.Windows.Forms.PictureBox myPictureBox;

        public Warrior()
        {
            this.speed = 0;
            this.power = 0;
            this.attackDistance = 0;

            //just creat a picturebox not add to mainForm
            this.myPictureBox = new System.Windows.Forms.PictureBox();
        }
//get functions
        public bool isDead() { return HP.isZero(); }
        public int getSpeed() { return speed; }
        public int getHP() { return HP.getValue(); }
        public int getPower() { return power; }
        public int getAttackDistance() { return attackDistance; }
//set functions just be used by subClass constructor 
        protected void setSpeed(int val)
        {
            if (val < 0) val = 0;
            speed = val;
        }
        protected void setHP(int val)
        {
            HP = new ValueBar(val,val);
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
//skill functions 
//move
        public virtual void moveTo(Point target)
        {
            if (this.distance(target) <= this.attackDistance || this.speed == 0)   
                return;//if target in your attack range , you shouldn't move
            
            if (target.getValue() < this.value) //target in your left
            {
                this.value -= speed;    //move to left

                if (target.getValue() > this.value) //when you move too over to left of target
                    this.value = target.getValue();
            }
            else if (target.getValue() > this.value)    //target in your right
            {
                this.value += speed;    //move to right

                if (target.getValue() < this.value) //when you move too over to right of target
                    this.value = target.getValue();
            }

            //change your picture status and move it
            changeStatusTo(Const.Status.move);
            myPictureBox.Left = value - leftFix;
            HP.fixPositionLeft(value - leftFix);
        }
//beKill
        public void beKill()
        {
            HP.reset();
            power = 0;
            attackDistance = 0;
            speed = 0;
            mainForm.Controls.Remove(myPictureBox);
            mainForm.Controls.Remove(HP.getBarPictureBox());
        }
//attack to warriors
        public virtual void attackTo(Warriors they)
        {
            if (they.size() == 0)
                return;

            if (this.distance(they.frontLineValue()) <= this.getAttackDistance())
            {
                changeStatusTo(Const.Status.attack);
                they.frontLineGroup()[0].beAttackFrom(this);
                Const.Sound._attack.Play();
            }
        }
//be attack from warrior
        public virtual void beAttackFrom(Warrior other)
        {
            this.HP.addValue(-other.getPower());
            if (this.HP.isZero()) 
                this.beKill();
        }
//add HP
        public void addHP(int value)
        {
            this.HP.addValue(value);
        }
//help to partner
        public virtual void helpTo(Warriors we)
        {
            ;
        }
//about pictureBox
//add pictureBox to mainForm
        public void addPictureBoxTo(System.Windows.Forms.Form mainForm)
        {
            

            myPictureBox.Width = Const.pictureWidth;
            myPictureBox.BackColor = Color.Transparent;
            myPictureBox.Left = value - leftFix;
            HP.fixPositionLeft(value - leftFix);

            this.mainForm = mainForm;
            this.mainForm.Controls.Add(myPictureBox);
            this.mainForm.Controls.Add(HP.getBarPictureBox());
        }
//set pictureBox location
        public void setPictureBoxTop(int y)
        {
            myPictureBox.Top = y;
            HP.setTop(y-10);
        }
//let pictureBox's left change to right
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
//chane image
        public void changeStatusTo(int status)
        {
            myPictureBox.Image = myRealStatus[status];
        }
    }
}
