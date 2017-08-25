using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class PlayBoard
    {
        private EnergyBar energyBar;

        private bool isPlayer;
        private BattleLine mainLine;

        public PlayBoard(EnergyBar energyBar , ref BattleLine mainLine, bool isPlayer=false)
        {
            this.energyBar = energyBar;
            this.isPlayer = isPlayer;
            this.mainLine = mainLine;
        }

        public void addEnergy(int value)
        {
            energyBar.addEnergy(value);
        }
        public int getEnergy() { return energyBar.getValue(); }

        public bool addSword()
        {
            if (energyBar.getValue() >= Const.SwordCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Sword());
                else
                    mainLine.AFieldPushWarrior(new Sword());

                addEnergy(-Const.SwordCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;    
        }

        public bool addArrow()
        {
            if (energyBar.getValue() >= Const.ArrowCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Arrow());
                else
                    mainLine.AFieldPushWarrior(new Arrow());

                addEnergy(-Const.ArrowCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addShield()
        {
            if (energyBar.getValue() >= Const.ShieldCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Shield());
                else
                    mainLine.AFieldPushWarrior(new Shield());

                addEnergy(-Const.ShieldCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRocket()
        {
            if (energyBar.getValue() >= Const.RocketCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Rocket());
                else
                    mainLine.AFieldPushWarrior(new Rocket());

                addEnergy(-Const.RocketCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addHatchet()
        {
            if (energyBar.getValue() >= Const.HatchetCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Hatchet());
                else
                    mainLine.AFieldPushWarrior(new Hatchet());

                addEnergy(-Const.HatchetCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addWall()
        {
            if (energyBar.getValue() >= Const.WallCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Wall());
                else
                    mainLine.AFieldPushWarrior(new Wall());

                addEnergy(-Const.WallCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

        public bool addRescue()
        {
            if (energyBar.getValue() >= Const.RescueCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Rescue());
                else
                    mainLine.AFieldPushWarrior(new Rescue());

                addEnergy(-Const.RescueCD);
                Const.Sound._click.Play();
                return true;
            }
            return false;
        }

    }
}
