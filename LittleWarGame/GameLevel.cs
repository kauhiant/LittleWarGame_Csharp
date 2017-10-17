using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LittleWarGame
{
    class GameLevel
    {
        public int level;
        public int mapLengh;
        List<WarriorData> warriors;

        public GameLevel( List<WarriorData> warriorsData , String fileRoute )
        {
            string[] allLine = File.ReadAllLines(fileRoute);

            string[] head = allLine[0].Split(' ');
            this.level = int.Parse(head[0]);
            this.mapLengh = int.Parse(head[1]);

            warriors = warriorsData;
            for (int i = 1; i < 8; ++i)
            {
                string[] each = allLine[i].Split(' ');
                warriors.Add(new WarriorData
                    (int.Parse(each[0]), int.Parse(each[1]), int.Parse(each[2]), int.Parse(each[3]))
                );
            }
        }

        public void set(int level)
        {
            if (level > 30) level = 30;
            int tmpLevel = (level < 7) ? 7 : level;
            string fileRoute = @"./log/M" + tmpLevel + ".txt";
            string[] allLine = File.ReadAllLines(fileRoute);
            string[] head = allLine[0].Split(' ');
            this.level = level;
            this.mapLengh = int.Parse(head[1]);
            Const.BStartPoint = Const.AStartPoint + this.mapLengh;

           // warriors = warriorsData;
            for (int i = 1; i < 8; ++i)
            {
                string[] each = allLine[i].Split(' ');
                warriors[i - 1].set
                    (int.Parse(each[0]), int.Parse(each[1]), int.Parse(each[2]), int.Parse(each[3]));
            }
        }

        public void saveToFile(string fileRoute)
        {
            string[] allLine = new string[8];
            allLine[0] = this.level.ToString() + ' ' + this.mapLengh.ToString() ;
            for (int i = 1; i < 8; ++i)
            {
                allLine[i] = warriors[i - 1].hp.ToString() + ' ' +
                    warriors[i - 1].speed.ToString() + ' ' +
                    warriors[i - 1].power.ToString() + ' ' +
                    warriors[i - 1].distance.ToString();
            }
            File.WriteAllLines(fileRoute, allLine);
        }

      /*  Random tmpRand = new Random();
        public void CreateLevelToFile(string fileRoute , int finalLevel=30)
        {
            while(level <= finalLevel)
            {
                string fileName = fileRoute + "M" + level + ".txt";
                
                for(int j = 0; j < 5; ++j)
                {
                    UpWarrior(tmpRand.Next(0, 6));
                }
                saveToFile(fileName);
                ++level;
            }
        }
        
        //warrior must be [0,6]
        private void UpWarrior(int warrior)
        {
            int index = warrior;
           
            switch (tmpRand.Next(0, 4))
            {
                case 0:
                    this.warriors[index].addHpFrom(Const.UpRefDat[index], 10000);
                    break;
                case 1:
                    this.warriors[index].addSpeedFrom(Const.UpRefDat[index], 10000);
                    break;
                case 2:
                    this.warriors[index].addPowerFrom(Const.UpRefDat[index], 10000);
                    break;
                case 3:
                    this.warriors[index].addDistanceFrom(Const.UpRefDat[index], 10000);
                    break;
            }
        }*/
    }
}
