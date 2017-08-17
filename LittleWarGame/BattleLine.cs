using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class BattleLine
    {
        private Point AField;
        private Point BField;
        private Warriors A;
        private Warriors B;

        public BattleLine(int ACastleLevel, int BCastleLevel,System.Windows.Forms.Form mainForm)
        {
            AField = new Point(Const.AStartPoint);
            BField = new Point(Const.BStartPoint);
            A = new Warriors(AField,mainForm,true);
            B = new Warriors(BField,mainForm);

            A.add(new Castle(ACastleLevel));
            B.add(new Castle(BCastleLevel));
            A.Back().setPictureBoxTop(Const.mainLineHeight - Const.castleHeight);
            B.Back().setPictureBoxTop(Const.mainLineHeight - Const.castleHeight);
        }

        public void nextStep()
        {
            //移動到對方的最前線
            A.moveTo(B.frontLine());
            B.moveTo(A.frontLine());
            //攻擊對方的最前線
            A.attackTo(B.frontLine());
            B.attackTo(A.frontLine());
            //把陣亡的戰士移除
            A.killDeadedWarrior();
            B.killDeadedWarrior();
        }

        public void AFieldPushWarrior(Warrior obj)
        {
            if(!A.isLose())
                A.add(obj);
        }

        public void BFieldPushWarrior(Warrior obj)
        {
            if(!B.isLose())
                B.add(obj);
        }

    }
}
