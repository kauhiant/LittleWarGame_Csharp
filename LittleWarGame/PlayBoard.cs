﻿using System;
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
            if (energy.getValue() >= Const.EnergyOf(Const.Warrior.Sword))
            {
                group.add(new Sword());
                energy.addEnergy(-Const.EnergyOf(Const.Warrior.Sword));
                Const.Sound._click.Play();
                return true;
            }
            return false;    
        }

        public bool addArrow()
        {
            if (level < 2) return false;
            if (energy.getValue() >= Const.EnergyOf(Const.Warrior.Arrow))
            {
                group.add(new Arrow());
                energy.addEnergy(-Const.EnergyOf(Const.Warrior.Arrow));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addShield()
        {
            if (level < 3) return false;
            if (energy.getValue() >= Const.EnergyOf(Const.Warrior.Shield))
            {
                group.add(new Shield());
                energy.addEnergy(-Const.EnergyOf(Const.Warrior.Shield));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addHatchet()
        {
            if (level < 4) return false;
            if (energy.getValue() >= Const.EnergyOf(Const.Warrior.Hatchet))
            {
                group.add(new Hatchet());
                energy.addEnergy(-Const.EnergyOf(Const.Warrior.Hatchet));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRocket()
        {
            if (level < 5) return false;
            if (energy.getValue() >= Const.EnergyOf(Const.Warrior.Rocket))
            {
                group.add(new Rocket());
                energy.addEnergy(-Const.EnergyOf(Const.Warrior.Rocket));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addWall()
        {
            if (level < 6) return false;
            if (energy.getValue() >= Const.EnergyOf(Const.Warrior.Wall))
            {
                group.add(new Wall());
                energy.addEnergy(-Const.EnergyOf(Const.Warrior.Wall));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRescue()
        {
            if (level < 7) return false;
            if (energy.getValue() >= Const.EnergyOf(Const.Warrior.Rescue))
            {
                group.add(new Rescue());
                energy.addEnergy(-Const.EnergyOf(Const.Warrior.Rescue));
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
            if (this.group.At(0).hp < 1000 || this.group.frontGroup()[0] is Rescue)
                this.fixRescueLine(this.group.getBaseLine().value);
            else
                this.fixRescueLine(this.group.frontLine().value + fixValue);
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
