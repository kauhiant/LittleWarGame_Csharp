using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class PlayBoard
    {
        private bool isPlayer;
        private CoolDownTime SwordCD;
        private CoolDownTime ArrowCD;
        private BattleLine mainLine;

        public PlayBoard(ref BattleLine mainLine, bool isPlayer=false)
        {
            this.isPlayer = isPlayer;
            SwordCD = new CoolDownTime(Const.SwordCD);
            ArrowCD = new CoolDownTime(Const.ArrowCD);
            this.mainLine = mainLine;
        }

        public void addSword()
        {
            if (SwordCD.isNotCoolDown())
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Sword());
                else
                    mainLine.AFieldPushWarrior(new Sword());

                SwordCD.record();
            }
                
        }

        public void addArrow()
        {
            if (ArrowCD.isNotCoolDown())
            {
                if (isPlayer)
                    mainLine.BFieldPushWarrior(new Arrow());
                else
                    mainLine.AFieldPushWarrior(new Arrow());

                ArrowCD.record();
            }
        }
    }
}
