﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rescue:Warrior
    {
        public Rescue()
        {
            myStatus = Const.imageList[Const.Warrior.Rescue];
            myRealStatus = myStatus[Const.Part.A];

            setSpeed(10);
            setHP(100);
            setPower(0);
            setAttackDistance(-1);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void helpTo(Warriors we)
        {
            if(this.distance(we.frontLineValue()) < 10)
                we.frontLineGroup()[0].addHP(20);
        }
        
    }
}