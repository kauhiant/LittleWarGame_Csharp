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

        private List<Button> _warriorButtonList;

        private EnergyBar myEnergyBar;
        private EnergyBar aiEnergyBar;
        private bool GameHaveWinner = false;
        private BattleLine mainLine;
        private PlayBoard AI;
        private PlayBoard Player;
        private Warriors A;
        private Warriors B;

        public Form1(int PlayerLevel)
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
            AI = new PlayBoard(aiEnergyBar, B, PlayerLevel+1);
            Player = new PlayBoard(myEnergyBar, A, PlayerLevel);
            mainLine = new BattleLine(AI,Player);
            //*************
            _warriorButtonList = new List<Button>();
            
            mainLine.linkPlayBoardA(AI);
            mainLine.linkPlayBoardB(Player);

            myEnergyBar.setLabel(ref _energyBar);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Little War Level " + Program.level.ToString();

            _sword.Text += Const.SwordCD.ToString();
            _arrow.Text += Const.ArrowCD.ToString();
            _shield.Text += Const.ShieldCD.ToString();
            _hatchet.Text += Const.HatchetCD.ToString();
            _rescue.Text += Const.RescueCD.ToString();
            _rocket.Text += Const.RocketCD.ToString();
            _wall.Text += Const.WallCD.ToString();

            _rescueLine.BackColor = Color.Transparent;
            _rescueLine.Left = Const.AStartPoint;

            _warriorButtonList.Add(_sword);
            _warriorButtonList.Add(_arrow);
            _warriorButtonList.Add(_shield);
            _warriorButtonList.Add(_hatchet);
            _warriorButtonList.Add(_rocket);
            _warriorButtonList.Add(_wall);
            _warriorButtonList.Add(_rescue);

            for(int i=Player.Level(); i<_warriorButtonList.Count; ++i)
            {
                _warriorButtonList.ElementAt(i).Hide();
            }

            if (Program.level == 7) _restart.Text = "結束";
            _restart.Hide();
            Program.isRestart = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            _getResouce.Enabled = true;
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

        private void _getResouce_Tick(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
            {
                aiEnergyBar.addEnergy(1);
                myEnergyBar.addEnergy(1);
                if (Program.level == 7)
                {
                    double r = rand.NextDouble();
                    if (r < 0.01)
                        aiEnergyBar.addEnergy(9);
                    else if (r < 0.1)
                        aiEnergyBar.addEnergy(4);
                }
            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
            {
                mainLine.nextStep();
                if (mainLine.isGameOver())
                {
                    gameTimer.Enabled = false;
                    _getResouce.Enabled = false;
                    GameHaveWinner = true;
                    if(!Player.group.isLose())
                        _restart.Show();
                }
                else
                {
                    AI.auto();
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
                if (e.X < Const.AStartPoint) _rescueLine.Left = Const.AStartPoint -20;
                else if (e.X > Const.BStartPoint) _rescueLine.Left = Const.BStartPoint - 20;
                else _rescueLine.Left = e.X - 20;

                if (e.X >= Const.BStartPoint || e.X <= Const.AStartPoint)
                    _rescueLine.BorderStyle = BorderStyle.Fixed3D;
                else
                    _rescueLine.BorderStyle = BorderStyle.None;

                Player.fixRescueLine(_rescueLine.Left + 20);
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
