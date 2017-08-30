using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Warriors
    {
        private bool Lose;
        private System.Windows.Forms.Form mainForm;
        private bool isReverse;
        private Point Field;    //start point of this group
        private List<Warrior> group;

        public Warriors(Point field , System.Windows.Forms.Form mainForm , bool isReverse=false)
        {
            this.Lose = false;
            this.mainForm = mainForm;
            this.isReverse = isReverse;
            this.Field = field;
            this.group = new List<Warrior>();
        }

        public void add(Warrior obj)
        {
            if (!Lose)
            {
                if (isReverse)
                    obj.setReverse();

                obj.setValue(Field.getValue());
                group.Add(obj);
                obj.addPictureBoxTo(mainForm);
            }
        }

        public int size()
        {
            return group.Count();
        }

        public void moveTo(Point target)
        {
            if (target == null)
                return;

            for (int i=0; i<size(); ++i)
                group[i].moveTo(target);
        }
        
        public void attackTo(Warriors they)
        {
            if (they.size() == 0)
                return;

            for (int i = 0; i < size(); ++i)
                this.group[i].attackTo(they);
        }

        public void helpTo(Warriors we)
        {
            for (int i = 0; i < size(); ++i)
                this.group[i].helpTo(we);
        }
        
        //最前線
        public Point frontLineValue()
        {
            int max = int.MinValue;
            Point front = null;
            for (int i=0; i<size(); ++i)
            {
                if (group[i].distance(Field) > max)
                {
                    front = group[i];
                    max = group[i].distance(Field);
                }
            }
            return front;
        }
        //最前線
        public List<Warrior> frontLineGroup()
        {
            int target = frontLineValue().getValue();
            List<Warrior> front = new List<Warrior>();
            for (int i = 0; i < size(); ++i)
            {
                if (group[i].getValue() == target)
                {
                    front.Add(group[i]);
                }
            }
            return front;
        }

        //把死掉的移除掉
        public int killDeadedWarrior()
        {
            int bonus = 0;
            for (int i = 0; i < group.Count(); ++i)
            {
                if (group[i].isDead())
                {
                    if (i == 0) {
                        for (int k = 0; k < group.Count(); ++k)
                            group[k].beKill();
                        group.Clear();
                        Lose = true;
                        mainForm.Text = "GameOver";
                        break;
                    } 
                    group[i].beKill();
                    bonus += group[i].getBonus();
                    group.RemoveAt(i);
                    --i;
                }
            }
            return bonus;
        }

        public bool isLose()
        {
            return Lose;
        }

        public Warrior At(int index)
        {
            return group.ElementAt(index);
        }

        public Warrior Back()
        {
            return group.Last();
        }
    }
}
