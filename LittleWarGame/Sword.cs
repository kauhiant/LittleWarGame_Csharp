using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleWarGame
{
    class Sword:Warrior
    {
        public Sword(bool isMe)
        {
            type = Warrior_Type.attacker;

            myStatus = Const.imageList[(int)WarriorList.Sword];
            myRealStatus = myStatus[Const.Part.A];

            if(isMe)
                setValueFrom(Program.playerData[0]);
            else
                setValueFrom(Program.AIData[0]);

            setBonus(1);
            CDTime.setCoolDownTime(10);

            img.Image = myRealStatus[(int)Status.move];
            img.Top = Const.mainLineHeight - Const.warriorHeight;
        }
    }
}
