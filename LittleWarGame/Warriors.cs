using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Warriors
    {
        private System.Windows.Forms.Form mainForm;
        private bool isReverse;
        private Point Field;    //start point of this group
        private List<Warrior> group;

        public Warriors(Point field,System.Windows.Forms.Form mainForm,bool isReverse=false)
        {
            this.mainForm = mainForm;
            this.isReverse = isReverse;
            this.Field = field;
            this.group = new List<Warrior>();
        }

        public void add(Warrior obj)
        {
            obj.setValue(Field.getValue());
            group.Add(obj);
            obj.addPictureBoxTo(mainForm);
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

        public void attackTo(Warrior target)
        {
            if (target == null)
                return;

            for (int i=0; i<size(); ++i)
                group[i].attack(target);
        }

        //最前線
        public Warrior frontLine()
        {
            int max = int.MinValue;
            Warrior front = null;
            for (int i=0; i<size(); ++i)
            {
                if (Math.Abs(group[i].distance(Field)) > max)
                {
                    front = group[i];
                    max = Math.Abs(group[i].distance(Field));
                }
            }
            return front;
        }

        //把死掉的移除掉
        public void killDeadedWarrior()
        {
            for (int i = 0; i < group.Count(); ++i)
            {
                if (group[i].getHP() == 0)
                {
                    group[i].beKill();
                    group.RemoveAt(i);
                    --i;
                }
            }
        }

        public bool isLose()
        {
            return group.Count == 0;
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
