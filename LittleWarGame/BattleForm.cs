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
    public partial class BattleForm : Form
    {
        public Graphics mainBattle;
        private Bitmap tmpMainBattle;

        private Random rand;
        private bool isAuto = false;

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
        public BattleForm()
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
            AI = new PlayBoard(aiEnergyBar, B, Program.AI.level);
            Player = new PlayBoard(myEnergyBar, A, Program.player.level,true);

            mainLine = new BattleLine(AI,Player);
            
            _warriorButtonList = new List<Button>();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

            this.BackgroundImage = Const.background;
            this.Icon = Const.icon;
            pictureBox1.BackColor = Color.Transparent;

            this.Text = "Little War Level " + Program.AI.level.ToString();
            myEnergyBar.setLabel(_energyBar);

            _superRocket.Text = "阿硯救我(" + Program.player.superRocket + ")";
            if (Program.player.superRocket <= 0)
                _superRocket.Hide();
            _Status.BackColor = Color.Transparent;
            _Status.Left = (Const.AStartPoint + Const.BStartPoint) / 2 - (_Status.Width / 2);
            _rescueLine.BackColor = Color.Transparent;

            _warriorButtonList.Add(_sword);
            _warriorButtonList.Add(_arrow);
            _warriorButtonList.Add(_shield);
            _warriorButtonList.Add(_hatchet);
            _warriorButtonList.Add(_rocket);
            _warriorButtonList.Add(_wall);
            _warriorButtonList.Add(_rescue);

            for (int i = 0; i < 7; ++i)
            {
                _warriorButtonList.ElementAt(i).Text = "";
                _warriorButtonList.ElementAt(i).BackgroundImage = Const.imageList[i + 1][0][0];
            }
            if (Player.Level() < 8)
            {
                for (int i = Player.Level(); i < _warriorButtonList.Count; ++i)
                {
                    _warriorButtonList.ElementAt(i).Hide();
                }
            }
            
            _restart.Hide();
            Program.isRestart = false;
        }
//for Create Warrior Button
        private void fixButtonsLight()
        {
            for(int i=0; i<7; ++i)
            {
                if (Player.getEnergy() < Const.WarriorEnergy[i])
                    setButtonLight(_warriorButtonList[i], true);
                else
                    setButtonLight(_warriorButtonList[i], false);
            }
        }
        private void setButtonLight(Button target , bool light)
        {
            if (light)
                target.Image = Const.mask;
            else
                target.Image = null;
        }

//
//Game Start AND Timers
//
        private void game_start(object sender, EventArgs e)
        {
            Button thisButton = sender as Button;
            if(thisButton.Text == "開始")
            {
                gameTimer.Enabled = true;
                _getResouce.Enabled = true;
                thisButton.Text = "暫停";
            }
            else if(thisButton.Text == "暫停")
            {
                gameTimer.Enabled = false;
                _getResouce.Enabled = false;
                thisButton.Text = "開始";
            }
        }

        private void _restart_Click(object sender, EventArgs e)
        {
            if (Program.player.level > 8)
            {
                Program.mainControl.updata();
                Program.mainControl.Show();
            }
            this.Close();
        }

        private void _getResouce_Tick(object sender, EventArgs e)
        {
            if (!GameHaveWinner)
            {
                aiEnergyBar.addEnergy(1);
                myEnergyBar.addEnergy(1);
                if (Program.player.level % 7 == 0)
                {
                    double r = rand.NextDouble();
                    if (r < 0.01)
                        aiEnergyBar.addEnergy(9);
                    else if (r < 0.1)
                        aiEnergyBar.addEnergy(4);
                }
                fixButtonsLight();
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (GameHaveWinner) return;

            Const.gameTime.clock();

            ClearImage();
            mainLine.nextStep();
            UpdateBattleImage();

            _Status.Text = (A.size()-1).ToString() + " : " + (B.size()-1).ToString();
            _Status.Left = (Const.AStartPoint + Const.BStartPoint) / 2 - (_Status.Width / 2);

            if (mainLine.isGameOver())
            {
                gameOver();
            }
            else
            {
                AI.auto();
                if (isAuto) Player.auto();
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
                gameTimer.Interval = 25;
                _getResouce.Interval = 125;
            }
            else
            {//再加速;
                _faster.Text = "普通";
                gameTimer.Interval = 50;
                _getResouce.Interval = 250;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_auto.Text == "手動")
            {//普通;
                _auto.Text = "自動";
                isAuto = true;
            }
            else
            {//再加速;
                _auto.Text = "手動";
                isAuto = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player.group.add(new SuperRocket());
            Program.player.useSuperRocket();
            _superRocket.Text = "阿硯救我(" + Program.player.superRocket + ")";

            if (Program.player.superRocket <= 0)
                _superRocket.Hide();
        }

        private void playerWin()
        {
            _Status.Text = "You Win";
            Program.isRestart = true;
            Program.player.playerGetBonus(Player.getEnergy() + (Player.group.At(0).hp / 100));

            if (Program.player.level < 8)
            {
                Program.player.levelUp();
                Program.AI.level += 1;
            }

            if (Program.player.level < this.AI.Level())
            {
                Program.player.levelUp();
            }
        }

        private void BattleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.player.level > 7 && Program.mainControl != null)
            {
                Program.mainControl.updata();
                Program.mainControl.Show();
            }
        }

        private void gameOver()
        {
            gameTimer.Enabled = false;
            _getResouce.Enabled = false;
            GameHaveWinner = true;

            if (Player.group.isLose())
                _Status.Text = "Game Over";
            else
                playerWin();

            if (Program.player.level < 8)
            {
                Program.player.saveToFile(@"./log/P0.txt");
                Program.player.SuperRocketInit();
            }
            
            if (Player.group.isLose() || Player.Level() > 7)
                _restart.Text = "結束";
            
            _restart.Show();
        }
    }
}
