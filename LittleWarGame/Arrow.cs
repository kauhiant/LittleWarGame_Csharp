using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class Arrow:Warrior
    {
        public Arrow(bool isMe)
        {
            type = Warrior_Type.attacker;

            myStatus = Const.imageList[(int)WarriorList.Arrow];
            myRealStatus = myStatus[Const.Part.A];
            if (isMe)
                setValueFrom(Program.playerData[1]);
            else
                setValueFrom(Program.AIData[1]);

            setBonus(5);
            
            CDTime.setCoolDownTime(15);

            img.Image = myRealStatus[(int)Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
