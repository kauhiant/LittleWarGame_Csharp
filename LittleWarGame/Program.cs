using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleWarGame
{
    static class Program
    {
        static public bool isRestart = false;
        static public int level = 1;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(level));
            while (isRestart)
            {
                ++level;
                if (level > 7) break;
                Application.Run(new Form1(level));
            }
        }
    }
}
