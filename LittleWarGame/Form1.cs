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
            _sword.Text += Const.SwordCD.ToString();
            _arrow.Text += Const.ArrowCD.ToString();
            _shield.Text += Const.ShieldCD.ToString();
            _hatchet.Text += Const.HatchetCD.ToString();
            _rescue.Text += Const.RescueCD.ToString();
            _rocket.Text += Const.RocketCD.ToString();
            _wall.Text += Const.WallCD.ToString();
        }
        private void show(ref Warrior obj1,ref Warrior obj2)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            _start.Hide();
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
        private int AINextIndex = 0;
        private bool AIDirect = true;
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
            {
                Player.addEnergy(1);
                AI.addEnergy(1);
                
                mainLine.nextStep();
                if(AIDirect == true)
                {
                    AINextIndex = rand.Next(1, 101);
                    AIDirect = false;
                }
                else
                {
                    if (AINextIndex < 100)
                        AIDirect = AI.addSword();
                    else if (AINextIndex < 60)
                        AIDirect = AI.addArrow();
                    else if (AINextIndex < 90)
                        AIDirect = AI.addShield();
                    else
                        AIDirect = AI.addRocket();
                }
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
                Player.addRocket();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addHatchet();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addWall();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addRescue();
        }
    }
}
