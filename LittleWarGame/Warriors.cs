﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Warriors
    {
        private Warriors enemy;
        
        private Point rescueLine;
        private Point baseLine;   //start point of this group
        
        private bool Lose;
        private bool Reverse;

        private System.Windows.Forms.Form mainForm;
        
        private List<Warrior> group;

        public Warriors(Point field , System.Windows.Forms.Form mainForm , bool isReverse=false)
        {
            this.Lose = false;
            this.mainForm = mainForm;
            this.Reverse = isReverse;
            this.baseLine = field;
            this.group = new List<Warrior>();
            
            this.rescueLine = baseLine;
        }

        public void add(Warrior obj)
        {
            if (!Lose)
            {
                group.Add(obj);
                if (Reverse)
                    obj.setReverse();

                obj.setValue(baseLine.getValue());
                obj.addPictureBoxTo(mainForm);
            }
        }

        public int size()
        {
            return group.Count();
        }

        public Point getBaseLine()
        {
            return baseLine;
        }

        public void setEnemy(Warriors value)
        {
            this.enemy = value;
        }

        public Warriors Enemy()
        {
            return enemy;
        }
        

        public void setRescueLine(Point value)
        {
            //need to fix range
            if (value.inRange(enemy.baseLine , this.baseLine) )
                this.rescueLine = value;
        }
        
        //最前線
        public Point frontLine()
        {
            int max = int.MinValue;
            Point front = null;
            for (int i = 0; i < size(); ++i)
            {
                if (group[i].distance(baseLine) > max)
                {
                    front = group[i];
                    max = group[i].distance(baseLine);
                }
            }
            return front;
        }
        //最前線
        public List<Warrior> frontGroup()
        {
            int target = frontLine().getValue();
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

        public void action()
        {
            if (enemy == null)
                return;//need to fix enemy and 2 line should initial

            Point tmpRescueLine =
                new Point( this.baseLine.chooseCloserFrom( this.rescueLine, enemy.frontLine() ) );

            foreach (Warrior each in group)
            {
                switch (each.Type())
                {
                    case Const.WarriorType.attacker:
                        each.moveTo(enemy.frontLine());
                        each.attackTo(enemy);
                        break;

                    case Const.WarriorType.shielder:
                        each.moveTo(enemy.frontLine());
                        break;

                    case Const.WarriorType.helper:
                        each.moveTo( tmpRescueLine );
                        each.helpTo(this);
                        break;
                }
            }
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

        public bool isReverse()
        {
            return Reverse;
        }
    }
}
