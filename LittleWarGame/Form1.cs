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
        private Warriors A;
        private Warriors B;

        public Form1()
        {
            rand = new Random();

            this.DoubleBuffered = true;//圖形移動不閃爍
            this.Opacity = 0.9;//透明度

            InitializeComponent();
            Const.ImageListInit();
            Const.SoundInit();

            A = new Warriors(new Point(Const.AStartPoint), this);
            B = new Warriors(new Point(Const.BStartPoint), this ,true);
            myEnergyBar = new EnergyBar();
            aiEnergyBar = new EnergyBar();
            AI = new PlayBoard(aiEnergyBar, A, 2);
            Player = new PlayBoard(myEnergyBar, B, 2);
            mainLine = new BattleLine(AI,Player,this);
            //*************
            

            

            mainLine.linkPlayBoardA(AI);
            mainLine.linkPlayBoardB(Player);

            myEnergyBar.setLabel(ref _energyBar);
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

            _rescueLine.BackColor = Color.Transparent;
            _rescueLine.Left = Const.AStartPoint;

              _restart.Hide();
            Program.isRestart = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            _start.Hide();
            myEnergyBar.addEnergy(10);
            aiEnergyBar.addEnergy(10);
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
                aiEnergyBar.addEnergy(1);
                myEnergyBar.addEnergy(1);
                
                mainLine.nextStep();
/*
                if(!GameHaveWinner && AI.group.frontGroup()[0] is Rescue)
                {
                    AI.fixRescueLine(Const.AStartPoint);
                }
                else
                {
                    AI.fixRescueLine(AI.group.frontLine().getValue());
                }*/

                if(AIDirect == true)
                {
                    AINextIndex = rand.Next(0, 60);
                    AIDirect = false;
                }
                else
                {
                    if (AINextIndex < 10)
                        AIDirect = AI.addSword();
                    else if (AINextIndex < 20)
                        AIDirect = AI.addArrow();
                    else if (AINextIndex < 30)
                        AIDirect = AI.addShield();
                    else if (AINextIndex < 40)
                        AIDirect = AI.addHatchet();
                    else if (AINextIndex < 50)
                        AIDirect = AI.addRocket();
                    else if (AINextIndex < 60)
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

        private bool mouseDown = false;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                if (e.X < Const.AStartPoint) _rescueLine.Left = Const.AStartPoint;
                else if (e.X > Const.BStartPoint) _rescueLine.Left = Const.BStartPoint;
                else _rescueLine.Left = e.X;
                if (e.X >= Const.BStartPoint)
                    _rescueLine.BorderStyle = BorderStyle.Fixed3D;
                else
                    _rescueLine.BorderStyle = BorderStyle.None;

                Player.fixRescueLine(_rescueLine.Left);
            }
        }

        private void _rescueLine_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled)
            {
                mouseDown = !mouseDown;
              //  Player.fixRescueLine(_rescueLine.Left);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (mouseDown && gameTimer.Enabled)
            {
                mouseDown = false;
              //  Player.fixRescueLine(_rescueLine.Left);
            }
        }
    }
}
