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

            this.fixValue = group.isReverse() ? 1 : -1;
            this.rand = new Random();

            direct = rand.Next(0, level);
        }
        
        public int getEnergy() { return energy.getValue(); }
        
        public int Level() { return level; }

        public void fixRescueLine(int value)
        {
            group.setRescueLine(new Point(value));
        }


        public bool addSword(bool isMe)
        {
            if (level < 1) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Sword))
            {
                group.add(new Sword(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Sword));
                Const.Sound._click.Play();
                return true;
            }
            return false;    
        }

        public bool addArrow(bool isMe)
        {
            if (level < 2) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Arrow))
            {
                group.add(new Arrow(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Arrow));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addShield(bool isMe)
        {
            if (level < 3) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Shield))
            {
                group.add(new Shield(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Shield));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addHatchet(bool isMe)
        {
            if (level < 4) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Hatchet))
            {
                group.add(new Hatchet(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Hatchet));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRocket(bool isMe)
        {
            if (level < 5) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Rocket))
            {
                group.add(new Rocket(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Rocket));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addWall(bool isMe)
        {
            if (level < 6) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Wall))
            {
                group.add(new Wall(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Wall));
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRescue(bool isMe)
        {
            if (level < 7) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Rescue))
            {
                group.add(new Rescue(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Rescue));
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
            {
                if(fixValue<0)
                    this.fixRescueLine(this.group.frontLine().value + Program.playerData[6].distance * fixValue);
                else
                    this.fixRescueLine(this.group.frontLine().value + Program.AIData[6].distance * fixValue);
            }
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
                    isCreate = addSword(false);
                    break;
                case 1:
                    isCreate = addArrow(false);
                    break;
                case 2:
                    isCreate = addShield(false);
                    break;
                case 3:
                    isCreate = addHatchet(false);
                    break;
                case 4:
                    isCreate = addRocket(false);
                    break;
                case 5:
                    isCreate = addWall(false);
                    break;
                case 6:
                    isCreate = addRescue(false);
                    break;
                default:
                    isCreate = true;
                    break;
            }

        }

    }
}
