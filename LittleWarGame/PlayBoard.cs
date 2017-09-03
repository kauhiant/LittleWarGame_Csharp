using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class PlayBoard
    {
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
        }
        
        public int getEnergy() { return energy.getValue(); }
        
        public void fixRescueLine(int value)
        {
            group.setRescueLine(new Point(value));
        }


        public bool addSword()
        {
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
            if (energy.getValue() >= Const.ShieldCD)
            {
                group.add(new Shield());
                energy.addEnergy(-Const.ShieldCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRocket()
        {
            if (energy.getValue() >= Const.RocketCD)
            {
                group.add(new Rocket());
                energy.addEnergy(-Const.RocketCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addHatchet()
        {
            if (energy.getValue() >= Const.HatchetCD)
            {
                group.add(new Hatchet());
                energy.addEnergy(-Const.HatchetCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addWall()
        {
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
            if (energy.getValue() >= Const.RescueCD)
            {
                group.add(new Rescue());
                energy.addEnergy(-Const.RescueCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

    }
}
