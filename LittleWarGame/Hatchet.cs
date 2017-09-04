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
            type = Const.WarriorType.attacker;

            myStatus = Const.imageList[Const.Warrior.Hatchet];
            myRealStatus = myStatus[Const.Part.A];
            setBonus(10);
            setSpeed(2);
            setHP(150);
            setPower(30);
            //setAttackDistance(0);

            CDTime.setCoolDownTime(3);

            myPictureBox.Image = myRealStatus[Const.Status.move];
            myPictureBox.Top = Const.mainLineHeight - Const.warriorHeight;
        }
        public override void attackTo(Warriors they)
        {
            if (CDTime.isCoolDown() || they.size() == 0)
                return;

            if (this.distance(they.frontLine()) <= this.getAttackDistance())
            {
                myPictureBox.Image = myRealStatus[Const.Status.attack];
                Const.Sound._attack.Play();
                attackGroup(they.frontGroup());
                CDTime.record();
            }
        }
        private void attackGroup(List<Warrior> group)
        {
            foreach(Warrior each in group)
            {
                each.beAttackFrom(this);
                if (each.isShield()) break;
            }
        }
    }
}
