using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleWarGame
{
    class WarriorData
    {

        public int level { get; private set; }
        public int hp { get; private set; }
        public int speed { get; private set; }
        public int power { get; private set; }
        public int distance { get; private set; }
        
        public WarriorData(int hp , int speed , int power , int distance ,int level = 1)
        {
            this.hp = hp;
            this.speed = speed;
            this.power = power;
            this.distance = distance;
            this.level = level;
        }

        public WarriorData(WarriorData each)
        {
            this.hp = each.hp;
            this.speed = each.speed;
            this.power = each.power;
            this.distance = each.distance;
            this.level = each.level;
        }

        public int addHpFrom(WarriorData refobj , int coin)
        {
            if (coin < level * 10) return coin;

            this.hp += refobj.hp;
            coin = level * 10;
            ++level;
            return coin;
        }

        public int addSpeedFrom(WarriorData refobj, int coin)
        {
            if (coin < level * 20) return coin;

            this.speed += refobj.speed;
            coin = level * 20;
            ++level;
            return coin;
        }

        public int addPowerFrom(WarriorData refobj, int coin)
        {
            if (coin < level * 20) return coin;

            this.power += refobj.power;
            coin = level * 20;
            ++level;
            return coin;
        }

        public int addDistanceFrom(WarriorData refobj, int coin)
        {
            if (coin < level * 20) return coin;

            this.distance += refobj.distance;
            coin = level * 20;
            ++level;
            return coin;
        }
    }
}
