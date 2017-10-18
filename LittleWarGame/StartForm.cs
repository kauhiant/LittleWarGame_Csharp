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

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Const.background;
            this.Icon = Const.icon;
        }

        private void _startNewGame_Click(object sender, EventArgs e)
        {
            Program.isBreak = false;
            Program.player = new GameData(Program.playerData , "new game");
            Program.AI = new GameLevel(Program.AIData, @"./log/M7.txt");
            Program.AI.level = 1;
            Const.BStartPoint = Const.AStartPoint + Program.AI.mapLengh;
            this.Close();
        }

        private void _loadGame_Click(object sender, EventArgs e)
        {
            Program.isBreak = false;
            Program.player = new GameData(Program.playerData, @"./log/P0.txt");
            Program.AI = new GameLevel(Program.AIData, @"./log/M7.txt");
            if (Program.player.level < 7) Program.AI.level = Program.player.level;
            Const.BStartPoint = Const.AStartPoint + Program.AI.mapLengh;
            this.Close();
        }

        private void _about_Click(object sender, EventArgs e)
        {
            FirstStepPassForm tmp = new FirstStepPassForm(true);
            tmp.Show();
        }

    }
}
