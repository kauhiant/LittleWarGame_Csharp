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

            AField = new Point(100);
            BField = new Point(500);
            A = new Warriors(AField,mainForm);
            B = new Warriors(BField,mainForm);

            A.add(new Castle(ACastleLevel));
            B.add(new Castle(BCastleLevel));
            
        }

        public void nextStep()
        {
            //移動到對方的最前線
            A.moveTo(B.frontBy(BField));
            B.moveTo(A.frontBy(AField));
            //攻擊對方的最前線
            A.attackTo(B.frontBy(BField));
            B.attackTo(A.frontBy(AField));
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
