﻿using System;
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

        public void addSword()
        {
            if (energyBar.getValue() >= Const.SwordCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Sword());
                else
                    mainLine.AFieldPushWarrior(new Sword());

                addEnergy(-Const.SwordCD);
            }
                
        }

        public void addArrow()
        {
            if (energyBar.getValue() >= Const.ArrowCD)
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Arrow());
                else
                    mainLine.AFieldPushWarrior(new Arrow());

                addEnergy(-Const.ArrowCD);
            }
        }

    }
}
