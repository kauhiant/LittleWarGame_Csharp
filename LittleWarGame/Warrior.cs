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

        protected Warrior_Type type;
        protected CoolDownTime CDTime;
        protected ValueBar HP;

        public int hp { get { return HP.getValue(); }  }
        public int bonus { get; private set; }
        public int speed { get; private set; }
        public int power { get; private set; }
        public int attackDistance { get; private set; }
        
        protected BattleForm mainForm;
        

        protected int leftFix = Const.pictureWidth;
        
        protected myPictureBox img;

        public Warrior()
        {
            this.bonus = 0;
            this.speed = 0;
            this.power = 0;
            this.attackDistance = 0;

            this.CDTime = new CoolDownTime();
            
            this.img = new myPictureBox();
        }
//get functions
        public Warrior_Type Type { get { return type; } }
        public bool isShielder() { return type == Warrior_Type.shielder; }
        public bool isDead() { return hp == 0; }
        public bool fullHP() { return HP.isFull(); }
//set functions just be used by subClass constructor 
        protected void setBonus(int val)
        {
            if (val < 0) val = 0;
            this.bonus = val;
        }

        protected void setHP(int val)
        {
            HP = new ValueBar(val);
        }
        
        protected void setSpeed(int val)
        {
            if (val < 0) val = 0;
            speed = val;
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
        
        protected void setValueFrom(WarriorData target)
        {
            this.HP = new ValueBar(target.hp);
            this.speed = target.speed;
            this.power = target.power;
            this.attackDistance = target.distance;
        }
//skill functions 
//move
        public virtual void moveTo(Point target)
        {
            changeStatusTo((int)Status.move);

            if (this.distance(target) <= this.attackDistance || this.speed == 0)   
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
//beKill
        public void beKill()
        {
            HP.reset();
            power = 0;
            attackDistance = 0;
            speed = 0;
            mainForm.Controls.Remove(HP.getBarPictureBox());
        }
//attack to warriors
        public virtual void attackTo(Warriors they)
        {
            if ( CDTime.isCoolDown() || they.size() == 0)
                return;

            if (this.distance(they.frontLine()) <= this.attackDistance)
            {
                changeStatusTo((int)Status.attack);
                they.frontGroup()[0].beAttackFrom(this);
                Const.Sound._attack.Play();
                CDTime.record();
            }
        }
//be attack from warrior
        public virtual void beAttackFrom(Warrior other)
        {
            this.HP.addValue(-other.power);
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
        public void addPictureBoxTo(BattleForm mainForm)
        {
            img.Left = value - leftFix;
            HP.fixPositionLeft(value - leftFix);

            this.mainForm = mainForm;
            mainForm.Controls.Add(HP.getBarPictureBox());
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
//change image
        public void changeStatusTo(int status)
        {
            img.Image = myRealStatus[status];
        }

        public void DrawImageOn(Graphics target)
        {
            target.DrawImage(this.img.Image, 
                img.location.X,img.location.Y, 
                img.Image.Width, img.Image.Height);
            //不知道為何 用 DrawImage(Image,Point) 大小就會變 如下**
            //target.DrawImage(img.Image, img.location);
        }
        
    }
}
