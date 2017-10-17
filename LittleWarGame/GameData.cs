using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LittleWarGame
{
    class GameData
    {
        public int level { get; private set; }
        public int coin { get; private set; }
        public int superRocket { get; private set; }
        List<WarriorData> warriors;

        public GameData(List<WarriorData> warriorsData , String fileRoute="new game")
        {
            warriors = warriorsData;
            if (fileRoute != "new game")
            {
                string[] allLine = File.ReadAllLines(fileRoute);
                string[] head = allLine[0].Split(' ');
                this.level = int.Parse(head[0]);
                this.coin = int.Parse(head[1]);
                this.superRocket = int.Parse(head[2]);
                
                for (int i = 1; i < 8; ++i)
                {
                    string[] each = allLine[i].Split(' ');
                    warriors.Add(new WarriorData
                        (int.Parse(each[0]), int.Parse(each[1]), int.Parse(each[2]), int.Parse(each[3]), int.Parse(each[4]))
                    );
                }
            }
            else
            {
                this.level = 1;
                this.coin = 0;
                this.superRocket = 1;
                foreach (WarriorData each in Const.InitData)
                    warriors.Add(new WarriorData(each));
            }
        }

        public void saveToFile(string fileRoute)
        {
            string[] allLine = new string[8];
            allLine[0] = this.level.ToString() + ' ' + this.coin.ToString() + ' ' + this.superRocket.ToString();
            for(int i=1; i<8; ++i)
            {
                allLine[i] = warriors[i - 1].hp.ToString() + ' ' +
                    warriors[i - 1].speed.ToString() + ' ' +
                    warriors[i - 1].power.ToString() + ' ' +
                    warriors[i - 1].distance.ToString() + ' '+
                    warriors[i - 1].level.ToString();
            }
            File.WriteAllLines(fileRoute , allLine);
        }

        public void levelUp() { this.level++;if (this.level > 30) this.level = 30; }
        public void getCoin(int value) { this.coin += value; }
        public void getSuperRocket() { this.superRocket++; }
        public void SuperRocketInit() { this.superRocket = 1; }

        public bool useSuperRocket()
        {
            if (this.superRocket == 0) return false;
            superRocket--;
            return true;
        }

        public bool buySuperRocket() {
            if (this.coin < 500) return false;

            this.coin -= 500;
            this.superRocket++;
            return true;
        }

        public int UpHp(WarriorList warrior)
        {
            int index = (int)warrior - 1;
            int pay = this.warriors[index].addHpFrom(Const.UpRefDat[index] , coin);

            if (pay > 0)
            {
                this.coin -= pay;
                return pay;
            }
            return pay;
        }

        public int UpSpeed(WarriorList warrior)
        {
            int index = (int)warrior - 1;
            int pay = this.warriors[index].addSpeedFrom(Const.UpRefDat[index], coin);
            if (pay > 0)
            {
                this.coin -= pay;
                return pay;
            }
            return pay;
        }

        public int UpPower(WarriorList warrior)
        {
            int index = (int)warrior - 1;
            int pay = this.warriors[index].addPowerFrom(Const.UpRefDat[index], coin);
            if (pay > 0)
            {
                this.coin -= pay;
                return pay;
            }
            return pay;
        }

        public int UpDistance(WarriorList warrior)
        {
            int index = (int)warrior - 1;
            int pay = this.warriors[index].addDistanceFrom(Const.UpRefDat[index], coin);
            if (pay > 0)
            {
                this.coin -= pay;
                return pay;
            }
            return pay;
        }
    }
}
