﻿using System;
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

            this.DoubleBuffered = true;//圖形移動不閃爍
            this.Opacity = 0.9;//透明度

            InitializeComponent();
            Const.ImageListInit();
            myEnergyBar = new EnergyBar(10);
            aiEnergyBar = new EnergyBar(10);
            mainLine = new BattleLine(2,2,this);
            AI = new PlayBoard(aiEnergyBar , ref mainLine);
            Player = new PlayBoard(myEnergyBar , ref mainLine, true);

            mainLine.linkPlayBoardA(AI);
            mainLine.linkPlayBoardB(Player);

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

              _restart.Hide();
            Program.isRestart = false;
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
                    AINextIndex = rand.Next(0, 200);
                    AIDirect = false;
                }
                else
                {
                    if (AINextIndex < 10)
                        AIDirect = AI.addSword();
                    else if (AINextIndex < 110)
                        AIDirect = AI.addArrow();
                    else if (AINextIndex < 120)
                        AIDirect = AI.addShield();
                    else if (AINextIndex < 140)
                        AIDirect = AI.addHatchet();
                    else if (AINextIndex < 160)
                        AIDirect = AI.addRocket();
                    else if (AINextIndex < 180)
                        AIDirect = AI.addWall();
                    else
                        AIDirect = AI.addRescue();
                    
                }
            }
            if (mainLine.isGameOver())
            {
                gameTimer.Enabled = false;
                GameHaveWinner = true;
                _restart.Show();
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

        private void _restart_Click(object sender, EventArgs e)
        {
            Program.isRestart = true;
            this.Close();
        }
    }
}
