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

        private bool isMe;
        private int level;

        public EnergyBar energy;
        public Warriors group;
        public BattleLine mainLine;

        public PlayBoard(EnergyBar energy , Warriors group, int level, bool isMe=false)
        {
            this.isMe = isMe;
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


        public bool addSword()
        {
            if (level < 1) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Sword))
            {
                group.add(new Sword(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Sword));
                return true;
            }
            return false;    
        }

        public bool addArrow()
        {
            if (level < 2) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Arrow))
            {
                group.add(new Arrow(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Arrow));
                return true;
            }
            return false;
        }

        public bool addShield()
        {
            if (level < 3) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Shield))
            {
                group.add(new Shield(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Shield));
                return true;
            }
            return false;
        }

        public bool addHatchet()
        {
            if (level < 4) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Hatchet))
            {
                group.add(new Hatchet(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Hatchet));
                return true;
            }
            return false;
        }

        public bool addRocket()
        {
            if (level < 5) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Rocket))
            {
                group.add(new Rocket(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Rocket));
                return true;
            }
            return false;
        }

        public bool addWall()
        {
            if (level < 6) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Wall))
            {
                group.add(new Wall(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Wall));
                return true;
            }
            return false;
        }

        public bool addRescue()
        {
            if (level < 7) return false;
            if (energy.getValue() >= Const.EnergyOf(WarriorList.Rescue))
            {
                group.add(new Rescue(isMe));
                energy.addEnergy(-Const.EnergyOf(WarriorList.Rescue));
                return true;
            }
            return false;
        }

        private void addWarrior(WarriorT wType = WarriorT.Default)
        {
            switch (wType)
            {
                case WarriorT.Sword:
                    isCreate = addSword();
                    break;
                case WarriorT.Arrow:
                    isCreate = addArrow();
                    break;
                case WarriorT.Shield:
                    isCreate = addShield();
                    break;
                case WarriorT.Hachet:
                    isCreate = addHatchet();
                    break;
                case WarriorT.Rocket:
                    isCreate = addRocket();
                    break;
                case WarriorT.Wall:
                    isCreate = addWall();
                    break;
                case WarriorT.Rescue:
                    isCreate = addRescue();
                    break;
                default:
                    isCreate = true;
                    break;
            }
        }

//AI
        private bool isCreate = false;
        private int direct;

        public void auto(WarriorT wType=WarriorT.Default)
        {
            autoFixLine();
            autoAddWarrior(wType);
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
        
        private void autoAddWarrior(WarriorT wType = WarriorT.Default)
        {
            if(wType != WarriorT.Default)
            {
                addWarrior(wType);
                return;
            }

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
