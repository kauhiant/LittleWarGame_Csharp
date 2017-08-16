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
        protected int speed;
        protected int HP;
        protected int power;
        protected int attackDistance;
        protected System.Windows.Forms.Form mainForm;
        public System.Windows.Forms.PictureBox myPictureBox;

        public Warrior(int HP=0,int power=0)
        {
            this.speed = 0;
            this.HP = HP;
            this.power = power;
            this.attackDistance = 0;

            //test picturebox
            this.myPictureBox = new System.Windows.Forms.PictureBox();
            myPictureBox.Image = Image.FromFile(@"./Sword.png");
           // myPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        }

        public int getSpeed() { return speed; }
        public int getHP() { return HP; }
        public int getPower() { return power; }
        public int getAttackDistance() { return attackDistance; }

        public void setSpeed(int val)
        {
            if (val < 0) val = 0;
            speed = val;
        }

        public void setHP(int val)
        {
            if (val < 0) val = 0;
            HP = val;
        }

        public void setPower(int val)
        {
            if (val < 0) val = 0;
            power = val;
        }

        public void setAttackDistance(int val)
        {
            if (val < 0) val = 0;
            attackDistance = val;
        }

        public void moveTo(Point target)
        {
            if (distance(target) <= attackDistance)
                return;

            if (target.getValue() < this.value)
            {
                this.value -= speed;
                if (target.getValue() > this.value)
                    this.value = target.getValue();
            }
            else if (target.getValue() > this.value)
            {
                this.value += speed;
                if (target.getValue() < this.value)
                    this.value = target.getValue();
            }
            //picturebox
            myPictureBox.Left = value;
        }

        public void beKill()
        {
            HP = 0;
            power = 0;
            attackDistance = 0;
            speed = 0;
            try
            {
                mainForm.Controls.RemoveAt(mainForm.Controls.IndexOf(myPictureBox));
                //*
                mainForm.Text = mainForm.Controls.Count.ToString();
            }
            catch (Exception )
            {
                mainForm.Text = "error";
            }
        }

        public void beAttack(int harm)
        {
            HP -= harm;
            if (HP < 0)
                this.beKill();
        }

        public void attack(Warrior obj)
        {
            if (this.distance(obj) <= attackDistance)
            {
                obj.beAttack(this.power);
            }
        }
        //for picturebox
        public void addPictureBoxTo(System.Windows.Forms.Form form)
        {
            form.Controls.Add(myPictureBox);
            myPictureBox.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            myPictureBox.Width = 50;
            myPictureBox.BackColor = Color.Transparent;
            myPictureBox.Left = value;
            mainForm = form;
            //*
            mainForm.Text = mainForm.Controls.Count.ToString();
        }
        public void setPictureBoxParent(Warrior p)
        {
            myPictureBox.Parent = p.myPictureBox;
        }
    }
}
