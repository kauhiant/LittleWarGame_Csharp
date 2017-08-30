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
        }

        public void nextStep()
        {
            if (!haveWinner)
            {
                int bonus;

                //移動到對方的最前線
                A.moveTo(B.frontLineValue());
                B.moveTo(A.frontLineValue());
                //攻擊對方的最前線
                A.attackTo(B);
                B.attackTo(A);
                //把陣亡的戰士移除//殺敵獎勵
                bonus =  A.killDeadedWarrior();
                BBoard.addEnergy(bonus);
                bonus =  B.killDeadedWarrior();
                ABoard.addEnergy(bonus);
                //輔助
                A.helpTo(A);
                B.helpTo(B);
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
