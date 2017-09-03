﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Rescue:Warrior
    {
        private Warrior lastHelpWarrior = null;
        public Rescue()
        {
            type = Const.WarriorType.helper;

            myStatus = Const.imageList[Const.Warrior.Rescue];
            myRealStatus = myStatus[Const.Part.A];
            //setBonus(0);
            setSpeed(15);
            setHP(100);
            setPower(0);
            setAttackDistance(-1);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void helpTo(Warriors we)
        {
            lastHelpWarrior = we.frontGroup()[0];
            if (this.distance(we.frontLine()) < 50)
                we.frontGroup()[0].addHP(20);
        }/*
        public override void moveTo(Point target)
        {
            if(lastHelpWarrior != null && lastHelpWarrior.getValue() != this.getValue() )
                base.moveTo(target);
        }*/
    }
}
