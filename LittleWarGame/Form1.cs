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
    public partial class Form1 : Form
    {
        private bool GameHaveWinner = false;
        private BattleLine mainLine;
        private PlayBoard AI;
        private PlayBoard Player;

        public Form1()
        {
            InitializeComponent();
            mainLine = new BattleLine(1,1,this);
            AI = new PlayBoard(ref mainLine);
            Player = new PlayBoard(ref mainLine, true);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void show(ref Warrior obj1,ref Warrior obj2)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!GameHaveWinner)
                Player.addSword();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!GameHaveWinner)
                Player.addArrow();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
            {
                mainLine.nextStep();
                AI.addSword();
                AI.addArrow();
            }
        }
    }
}
