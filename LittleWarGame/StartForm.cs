using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LittleWarGame
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void _startNewGame_Click(object sender, EventArgs e)
        {
            Program.isBreak = false;
            Program.player = new GameData(Program.playerData , "new game");
            GameLevel tmp = new GameLevel(Program.AIData, @"./log/testData2.txt");
            Const.BStartPoint = Const.AStartPoint + tmp.mapLengh;
            this.Close();
        }

        private void _loadGame_Click(object sender, EventArgs e)
        {
            Program.isBreak = false;
            Program.player = new GameData(Program.playerData, @"./log/testData.txt");
            GameLevel tmp = new GameLevel(Program.AIData, @"./log/testData2.txt");
            Const.BStartPoint = Const.AStartPoint + tmp.mapLengh;
            this.Close();
        }
    }
}
