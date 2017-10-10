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
    }
}
