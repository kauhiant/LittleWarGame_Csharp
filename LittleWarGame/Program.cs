using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleWarGame
{
    static class Program
    {
       // static public BattleForm mainBattle;
        static public bool isRestart = true;
        static public bool isBreak = true;
        static public List<WarriorData> playerData, AIData;
        static public GameData player;
        static public GameLevel AI;
        static public ControlForm mainControl;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Const.ImageListInit();
            Const.SoundInit();
            Const.WarriorDataInitial();
            playerData = new List<WarriorData>();
            AIData = new List<WarriorData>();

            Application.Run(new StartForm());
            if (!isBreak)
            {
                if (player.level < 8)
                    while (isRestart)
                    {
                        Application.Run(new BattleForm(player.level));
                        if (player.level == 8)
                        {
                            Application.Run(new FirstStepPassForm());
                            player.saveToFile(@"./log/P0.txt");
                            break;
                        }
                    }
                else
                {
                    mainControl = new ControlForm();
                    mainControl.updata();
                    Application.Run(mainControl);
                }
            }
        }
    }
}
