using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Warriors
    {
        private Point Field;
        private List<Warrior> group;
        private System.Windows.Forms.Form mainForm;
        private bool isReverse;

        public Warriors(Point field,System.Windows.Forms.Form mainForm,bool isReverse=false)
        {
            this.group = new List<Warrior>();
            this.Field = field;
            this.mainForm = mainForm;
            this.isReverse = isReverse;
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
            {
                group[i].attack(target);
            }
        }

        //離target最遠
        public Warrior frontBy(Point target)
        {
            int max = int.MinValue;
            Warrior front = null;
            for (int i=0; i<size(); ++i)
            {
                if (Math.Abs(group[i].getValue() - target.getValue()) > max)
                {
                    front = group[i];
                    max = Math.Abs(group[i].getValue() - target.getValue());
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
    }
}
