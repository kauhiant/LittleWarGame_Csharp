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
        private Random rand;

        private EnergyBar myEnergyBar;
        private EnergyBar aiEnergyBar;
        private bool GameHaveWinner = false;
        private BattleLine mainLine;
        private PlayBoard AI;
        private PlayBoard Player;

        public Form1()
        {
            rand = new Random();

            InitializeComponent();
            Const.ImageListInit();
            myEnergyBar = new EnergyBar(10);
            aiEnergyBar = new EnergyBar(10);
            mainLine = new BattleLine(1,1,this);
            AI = new PlayBoard(aiEnergyBar , ref mainLine);
            Player = new PlayBoard(myEnergyBar , ref mainLine, true);
            myEnergyBar.setLabel(ref textBox1);
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
                Player.addEnergy(1);
                AI.addEnergy(1);
                
                mainLine.nextStep();
                if (rand.Next(1, 10) == 1)
                    AI.addSword();
                else if (rand.Next(1, 5) == 1)
                    AI.addArrow();
                else
                    AI.addShield();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addShield();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addRRocket();
        }
    }
}
