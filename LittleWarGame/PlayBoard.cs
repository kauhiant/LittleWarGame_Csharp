using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class PlayBoard
    {
        private int fixValue;
        private Random rand;

        private int level;

        public EnergyBar energy;
        public Warriors group;
        public BattleLine mainLine;

        public PlayBoard(EnergyBar energy , Warriors group,int level)
        {
            this.energy = energy;
            this.group = group;
            this.level = level;
            this.group.add(new Castle(this.level));

            this.fixValue = group.isReverse() ? 10 : -10;
            this.rand = new Random();

            direct = rand.Next(0, level);
        }
        
        public int getEnergy() { return energy.getValue(); }
        
        public int Level() { return level; }

        public void fixRescueLine(int value)
        {
            group.setRescueLine(new Point(value));
        }


        public bool addSword()
        {
            if (level < 1) return false;
            if (energy.getValue() >= Const.SwordCD)
            {
                group.add(new Sword());
                energy.addEnergy(-Const.SwordCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;    
        }

        public bool addArrow()
        {
            if (level < 2) return false;
            if (energy.getValue() >= Const.ArrowCD)
            {
                group.add(new Arrow());
                energy.addEnergy(-Const.ArrowCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addShield()
        {
            if (level < 3) return false;
            if (energy.getValue() >= Const.ShieldCD)
            {
                group.add(new Shield());
                energy.addEnergy(-Const.ShieldCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addHatchet()
        {
            if (level < 4) return false;
            if (energy.getValue() >= Const.HatchetCD)
            {
                group.add(new Hatchet());
                energy.addEnergy(-Const.HatchetCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRocket()
        {
            if (level < 5) return false;
            if (energy.getValue() >= Const.RocketCD)
            {
                group.add(new Rocket());
                energy.addEnergy(-Const.RocketCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addWall()
        {
            if (level < 6) return false;
            if (energy.getValue() >= Const.WallCD)
            {
                group.add(new Wall());
                energy.addEnergy(-Const.WallCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRescue()
        {
            if (level < 7) return false;
            if (energy.getValue() >= Const.RescueCD)
            {
                group.add(new Rescue());
                energy.addEnergy(-Const.RescueCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }
//AI
        public void auto()
        {
            autoFixLine();
            autoAddWarrior();
        }

        private void autoFixLine()
        {
            if (this.group.At(0).getHP() < 1000 || this.group.frontGroup()[0] is Rescue)
                this.fixRescueLine(this.group.getBaseLine().getValue());
            else
                this.fixRescueLine(this.group.frontLine().getValue() + fixValue);
        }

        private bool isCreate = false;
        private int direct;

        private void autoAddWarrior()
        {
            if (isCreate)
                direct = rand.Next(0, level);
            switch (direct)
            {
                case 0:
                    isCreate = addSword();
                    break;
                case 1:
                    isCreate = addArrow();
                    break;
                case 2:
                    isCreate = addShield();
                    break;
                case 3:
                    isCreate = addHatchet();
                    break;
                case 4:
                    isCreate = addRocket();
                    break;
                case 5:
                    isCreate = addWall();
                    break;
                case 6:
                    isCreate = addRescue();
                    break;
                default:
                    isCreate = true;
                    break;
            }

        }

    }
}
