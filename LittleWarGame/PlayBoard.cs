using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LittleWarGame
{
    class PlayBoard
    {
        private SoundPlayer click = new SoundPlayer();
        private EnergyBar energyBar;

        private bool isPlayer;
        private BattleLine mainLine;

        public PlayBoard(EnergyBar energyBar , ref BattleLine mainLine, bool isPlayer=false)
        {
            this.energyBar = energyBar;
            this.isPlayer = isPlayer;
            this.mainLine = mainLine;

            click.SoundLocation = @"./audio/click.wav";
        }

        public void addEnergy(int value)
        {
            energyBar.addEnergy(value);
        }

        public bool addSword()
        {
            if (energyBar.getValue() >= Const.SwordCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Sword());
                else
                    mainLine.AFieldPushWarrior(new Sword());

                addEnergy(-Const.SwordCD);
                click.Play();
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
                click.Play();
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
                click.Play();
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
                click.Play();
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
                click.Play();
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
                click.Play();
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
                click.Play();
                return true;
            }
            return false;
        }

    }
}
