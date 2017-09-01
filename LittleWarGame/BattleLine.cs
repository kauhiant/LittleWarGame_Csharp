using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class BattleLine
    {
        private PlayBoard ABoard;
        private PlayBoard BBoard;
        private EnergyBar AEnergy;
        private EnergyBar BEnergy;
        private Warriors A;
        private Warriors B;

        private bool haveWinner;

        public BattleLine(PlayBoard ABoard , PlayBoard BBoard , System.Windows.Forms.Form mainForm)
        {
            haveWinner = false;

            ABoard.mainLine = this;
            BBoard.mainLine = this;

            this.ABoard = ABoard;
            this.BBoard = BBoard;
            this.AEnergy = ABoard.energy;
            this.BEnergy = BBoard.energy;
            this.A = ABoard.group;
            this.B = BBoard.group;

            B.At(0).changeStatusTo(Const.Status.move);

            A.setEnemy(B);
            B.setEnemy(A);
        }

        public void nextStep()
        {
            if (!haveWinner)
            {
                int bonus;

                A.action();
                B.action();
                //把陣亡的戰士移除//殺敵獎勵
                bonus =  A.killDeadedWarrior();
                BEnergy.addEnergy(bonus);
                bonus =  B.killDeadedWarrior();
                AEnergy.addEnergy(bonus);
                //have loser?
                if (A.isLose() || B.isLose())
                {
                    haveWinner = true;
                }
            }
        }

        public void AFieldPushWarrior(Warrior obj)
        {
            if(!haveWinner)
                A.add(obj);
        }

        public void BFieldPushWarrior(Warrior obj)
        {
            if (!haveWinner)
                B.add(obj);
        }

        public bool isGameOver()
        {
            return haveWinner;
        }

        public void linkPlayBoardA(PlayBoard A)
        {
            this.ABoard = A;
        }

        public void linkPlayBoardB(PlayBoard B)
        {
            this.BBoard = B;
        }
    }
}
