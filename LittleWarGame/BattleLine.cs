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

        private bool haveWinner;
        private Point AField;
        private Point BField;
        private Warriors A;
        private Warriors B;

        public BattleLine(int ACastleLevel, int BCastleLevel,System.Windows.Forms.Form mainForm)
        {
            haveWinner = false;

            AField = new Point(Const.AStartPoint);
            BField = new Point(Const.BStartPoint);
            A = new Warriors(AField , mainForm);
            B = new Warriors(BField , mainForm , true);

            A.add(new Castle(ACastleLevel));
            B.add(new Castle(BCastleLevel));
            A.Back().setPictureBoxTop(Const.mainLineHeight - Const.castleHeight);
            B.Back().setPictureBoxTop(Const.mainLineHeight - Const.castleHeight);

            B.At(0).changeStatusTo(0);
           // nextStep();
        }

        public void nextStep()
        {
            if (!haveWinner)
            {
                //移動到對方的最前線
                A.moveTo(B.frontLineValue());
                B.moveTo(A.frontLineValue());
                //攻擊對方的最前線
                A.attackTo(B);
                B.attackTo(A);
                //把陣亡的戰士移除
                A.killDeadedWarrior();
                B.killDeadedWarrior();
                //輔助
                A.helpTo(A);
                B.helpTo(B);
                //殺敵獎勵
                  ABoard.addEnergy(5);
                  BBoard.addEnergy(10);
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
