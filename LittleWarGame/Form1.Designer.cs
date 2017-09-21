namespace LittleWarGame
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._start = new System.Windows.Forms.Button();
            this._restart = new System.Windows.Forms.Button();
            this._energyBar = new System.Windows.Forms.TextBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this._getResouce = new System.Windows.Forms.Timer(this.components);
            this._rescueLine = new System.Windows.Forms.PictureBox();
            this._sword = new System.Windows.Forms.Button();
            this._arrow = new System.Windows.Forms.Button();
            this._shield = new System.Windows.Forms.Button();
            this._hatchet = new System.Windows.Forms.Button();
            this._rocket = new System.Windows.Forms.Button();
            this._wall = new System.Windows.Forms.Button();
            this._rescue = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._ACount = new System.Windows.Forms.Label();
            this._BCount = new System.Windows.Forms.Label();
            this._faster = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._rescueLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _start
            // 
            this._start.Location = new System.Drawing.Point(125, 175);
            this._start.Name = "_start";
            this._start.Size = new System.Drawing.Size(75, 25);
            this._start.TabIndex = 0;
            this._start.Text = "開始";
            this._start.UseVisualStyleBackColor = true;
            this._start.Click += new System.EventHandler(this.game_start);
            // 
            // _restart
            // 
            this._restart.Location = new System.Drawing.Point(205, 175);
            this._restart.Name = "_restart";
            this._restart.Size = new System.Drawing.Size(75, 25);
            this._restart.TabIndex = 9;
            this._restart.Text = "下一關";
            this._restart.UseVisualStyleBackColor = true;
            this._restart.Click += new System.EventHandler(this._restart_Click);
            // 
            // _energyBar
            // 
            this._energyBar.BackColor = System.Drawing.Color.Green;
            this._energyBar.Location = new System.Drawing.Point(20, 175);
            this._energyBar.Name = "_energyBar";
            this._energyBar.ReadOnly = true;
            this._energyBar.Size = new System.Drawing.Size(75, 22);
            this._energyBar.TabIndex = 0;
            this._energyBar.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // _getResouce
            // 
            this._getResouce.Interval = 500;
            this._getResouce.Tick += new System.EventHandler(this._getResouce_Tick);
            // 
            // _rescueLine
            // 
            this._rescueLine.BackColor = System.Drawing.SystemColors.ControlDark;
            this._rescueLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._rescueLine.Image = ((System.Drawing.Image)(resources.GetObject("_rescueLine.Image")));
            this._rescueLine.Location = new System.Drawing.Point(80, 0);
            this._rescueLine.Name = "_rescueLine";
            this._rescueLine.Size = new System.Drawing.Size(20, 20);
            this._rescueLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._rescueLine.TabIndex = 0;
            this._rescueLine.TabStop = false;
            this._rescueLine.Click += new System.EventHandler(this._rescueLine_Click);
            // 
            // _sword
            // 
            this._sword.Location = new System.Drawing.Point(20, 200);
            this._sword.Name = "_sword";
            this._sword.Size = new System.Drawing.Size(75, 23);
            this._sword.TabIndex = 1;
            this._sword.Text = "劍兵";
            this._sword.UseVisualStyleBackColor = true;
            this._sword.Click += new System.EventHandler(this.addSword);
            // 
            // _arrow
            // 
            this._arrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._arrow.Location = new System.Drawing.Point(100, 200);
            this._arrow.Name = "_arrow";
            this._arrow.Size = new System.Drawing.Size(75, 23);
            this._arrow.TabIndex = 2;
            this._arrow.Text = "弓兵";
            this._arrow.UseVisualStyleBackColor = true;
            this._arrow.Click += new System.EventHandler(this.addArrow);
            // 
            // _shield
            // 
            this._shield.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._shield.Location = new System.Drawing.Point(180, 200);
            this._shield.Name = "_shield";
            this._shield.Size = new System.Drawing.Size(75, 23);
            this._shield.TabIndex = 3;
            this._shield.Text = "盾牌";
            this._shield.UseVisualStyleBackColor = true;
            this._shield.Click += new System.EventHandler(this.addShield);
            // 
            // _hatchet
            // 
            this._hatchet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._hatchet.Location = new System.Drawing.Point(260, 200);
            this._hatchet.Name = "_hatchet";
            this._hatchet.Size = new System.Drawing.Size(75, 23);
            this._hatchet.TabIndex = 4;
            this._hatchet.Text = "斧手";
            this._hatchet.UseVisualStyleBackColor = true;
            this._hatchet.Click += new System.EventHandler(this.addHachet);
            // 
            // _rocket
            // 
            this._rocket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._rocket.Location = new System.Drawing.Point(340, 200);
            this._rocket.Name = "_rocket";
            this._rocket.Size = new System.Drawing.Size(75, 23);
            this._rocket.TabIndex = 5;
            this._rocket.Text = "火箭";
            this._rocket.UseVisualStyleBackColor = true;
            this._rocket.Click += new System.EventHandler(this.addRocket);
            // 
            // _wall
            // 
            this._wall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._wall.Location = new System.Drawing.Point(420, 200);
            this._wall.Name = "_wall";
            this._wall.Size = new System.Drawing.Size(75, 23);
            this._wall.TabIndex = 6;
            this._wall.Text = "鐵壁";
            this._wall.UseVisualStyleBackColor = true;
            this._wall.Click += new System.EventHandler(this.addWall);
            // 
            // _rescue
            // 
            this._rescue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._rescue.Location = new System.Drawing.Point(500, 200);
            this._rescue.Name = "_rescue";
            this._rescue.Size = new System.Drawing.Size(75, 23);
            this._rescue.TabIndex = 7;
            this._rescue.Text = "醫護";
            this._rescue.UseVisualStyleBackColor = true;
            this._rescue.Click += new System.EventHandler(this.addRescue);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 100);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // _ACount
            // 
            this._ACount.AutoSize = true;
            this._ACount.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._ACount.Location = new System.Drawing.Point(0, 20);
            this._ACount.Name = "_ACount";
            this._ACount.Size = new System.Drawing.Size(31, 35);
            this._ACount.TabIndex = 11;
            this._ACount.Text = "0";
            // 
            // _BCount
            // 
            this._BCount.AutoSize = true;
            this._BCount.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BCount.Location = new System.Drawing.Point(462, 20);
            this._BCount.Name = "_BCount";
            this._BCount.Size = new System.Drawing.Size(31, 35);
            this._BCount.TabIndex = 12;
            this._BCount.Text = "0";
            // 
            // _faster
            // 
            this._faster.Location = new System.Drawing.Point(286, 175);
            this._faster.Name = "_faster";
            this._faster.Size = new System.Drawing.Size(75, 25);
            this._faster.TabIndex = 13;
            this._faster.Text = "普通";
            this._faster.UseVisualStyleBackColor = true;
            this._faster.Click += new System.EventHandler(this._faster_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(600, 250);
            this.Controls.Add(this._faster);
            this.Controls.Add(this._BCount);
            this.Controls.Add(this._ACount);
            this.Controls.Add(this._rescueLine);
            this.Controls.Add(this._restart);
            this.Controls.Add(this._rescue);
            this.Controls.Add(this._wall);
            this.Controls.Add(this._hatchet);
            this.Controls.Add(this._rocket);
            this.Controls.Add(this._shield);
            this.Controls.Add(this._energyBar);
            this.Controls.Add(this._arrow);
            this.Controls.Add(this._sword);
            this.Controls.Add(this._start);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Little War Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this._rescueLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _start;
        private System.Windows.Forms.Button _sword;
        private System.Windows.Forms.Button _arrow;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox _energyBar;
        private System.Windows.Forms.Button _shield;
        private System.Windows.Forms.Button _rocket;
        private System.Windows.Forms.Button _hatchet;
        private System.Windows.Forms.Button _wall;
        private System.Windows.Forms.Button _rescue;
        private System.Windows.Forms.Button _restart;
        private System.Windows.Forms.PictureBox _rescueLine;
        private System.Windows.Forms.Timer _getResouce;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label _ACount;
        private System.Windows.Forms.Label _BCount;
        private System.Windows.Forms.Button _faster;
    }
}

