﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class Hatchet:Warrior
    {
        public Hatchet()
        {
            myStatus = Const.imageList[Const.Warrior.Hatchet];
            myRealStatus = myStatus[Const.Part.A];

            setSpeed(8);
            setHP(200);
            setPower(50);
            //setAttackDistance(0);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void attackTo(Warriors they)
        {
            if (they.size() == 0)
                return;

            if (this.distance(they.frontLineValue()) <= this.getAttackDistance())
            {
                myPictureBox.Image = myRealStatus[Const.Status.attack];
                attackGroup(they.frontLineGroup());
            }
        }
        private void attackGroup(List<Warrior> group)
        {
            foreach(Warrior each in group)
            {
                each.beAttackFrom(this);
            }
        }
    }
}
