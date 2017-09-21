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
        public Graphics mainBattle;
        private Bitmap tmpMainBattle;

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
//
//Initation
//
        public Form1(int PlayerLevel)
        {
            
            rand = new Random();

            this.DoubleBuffered = true;//圖形移動不閃爍
            this.Opacity = 0.9;//透明度
            
            InitializeComponent();
            battlePictureInit();
            this.Width = Const.BStartPoint + 100;
            pictureBox1.Width = this.Width;

            A = new Warriors(new Point(Const.AStartPoint), this);
            B = new Warriors(new Point(Const.BStartPoint), this ,true);
            myEnergyBar = new EnergyBar(10);
            aiEnergyBar = new EnergyBar(10);
            AI = new PlayBoard(aiEnergyBar, B, PlayerLevel+1);
            Player = new PlayBoard(myEnergyBar, A, PlayerLevel);

            mainLine = new BattleLine(AI,Player);
            
            _warriorButtonList = new List<Button>();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            

            pictureBox1.BackColor = Color.Transparent;

            this.Text = "Little War Level " + Program.level.ToString();
            myEnergyBar.setLabel(_energyBar);

            _ACount.BackColor = Color.Transparent;
            _BCount.BackColor = Color.Transparent;
            _ACount.Left = Const.AStartPoint - Const.pictureWidth;
            _BCount.Left = Const.BStartPoint;

            _sword.Text += Const.SwordCD.ToString();
            _arrow.Text += Const.ArrowCD.ToString();
            _shield.Text += Const.ShieldCD.ToString();
            _hatchet.Text += Const.HatchetCD.ToString();
            _rescue.Text += Const.RescueCD.ToString();
            _rocket.Text += Const.RocketCD.ToString();
            _wall.Text += Const.WallCD.ToString();

            _rescueLine.BackColor = Color.Transparent;

            _warriorButtonList.Add(_sword);
            _warriorButtonList.Add(_arrow);
            _warriorButtonList.Add(_shield);
            _warriorButtonList.Add(_hatchet);
            _warriorButtonList.Add(_rocket);
            _warriorButtonList.Add(_wall);
            _warriorButtonList.Add(_rescue);

            for(int i=Player.Level(); i<_warriorButtonList.Count; ++i)
                _warriorButtonList.ElementAt(i).Hide();

            if (Program.level == 7) _restart.Text = "結束";

            _restart.Hide();
            Program.isRestart = false;
        }
//
//Game Start AND Timers
//
        private void game_start(object sender, EventArgs e)
        {
            gameTimer.Enabled = true;
            _getResouce.Enabled = true;
            _start.Hide();
        }

        private void _restart_Click(object sender, EventArgs e)
        {
            Program.isRestart = true;
            this.Close();
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
            if (GameHaveWinner) return;

            Const.gameTime.clock();
            Text = Const.gameTime.Value.ToString();

            ClearImage();
            mainLine.nextStep();
            UpdateBattleImage();
            _ACount.Text = (A.size()-1).ToString();
            _BCount.Text = (B.size()-1).ToString();

            if (mainLine.isGameOver())
            {
                gameTimer.Enabled = false;
                _getResouce.Enabled = false;
                GameHaveWinner = true;
                if (!Player.group.isLose())
                    _restart.Show();
            }
            else
            {
                AI.auto();
            }
        }
//
//Add-Warrior Buttons
//
        private void addSword(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addSword();
        }

        private void addArrow(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addArrow();
        }

        private void addShield(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addShield();
        }

        private void addRocket(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addRocket();
        }

        private void addHachet(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addHatchet();
        }

        private void addWall(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addWall();
        }

        private void addRescue(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
                Player.addRescue();
        }
//
//move RescueLine      
//
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
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
                mouseDown = false;
        }


     //   show Warriors Battle
        private void battlePictureInit()
        {
            tmpMainBattle = new Bitmap(Const.BStartPoint+100 , 150);
            mainBattle = Graphics.FromImage(tmpMainBattle);
        }
        public void ClearImage()
        {
            mainBattle.Clear(pictureBox1.BackColor);
        }
        public void UpdateBattleImage()
        {
            pictureBox1.Image = tmpMainBattle;
        }

        private void _faster_Click(object sender, EventArgs e)
        {
            if(_faster.Text == "普通")
            {//普通;
                _faster.Text = "加速";
                gameTimer.Interval = 50;
                _getResouce.Interval = 250;
            }
            else if(_faster.Text == "加速")
            {//加速;
                _faster.Text = "再加速";
                gameTimer.Interval = 25;
                _getResouce.Interval = 125;
            }
            else
            {//再加速;
                _faster.Text = "普通";
                gameTimer.Interval = 100;
                _getResouce.Interval = 500;
            }
            
        }
    }
}
