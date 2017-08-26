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
            this._sword = new System.Windows.Forms.Button();
            this._arrow = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._shield = new System.Windows.Forms.Button();
            this._rocket = new System.Windows.Forms.Button();
            this._hatchet = new System.Windows.Forms.Button();
            this._wall = new System.Windows.Forms.Button();
            this._rescue = new System.Windows.Forms.Button();
            this._restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _start
            // 
            this._start.Location = new System.Drawing.Point(123, 183);
            this._start.Name = "_start";
            this._start.Size = new System.Drawing.Size(75, 23);
            this._start.TabIndex = 0;
            this._start.Text = "開始";
            this._start.UseVisualStyleBackColor = true;
            this._start.Click += new System.EventHandler(this.button1_Click);
            // 
            // _sword
            // 
            this._sword.Location = new System.Drawing.Point(17, 211);
            this._sword.Name = "_sword";
            this._sword.Size = new System.Drawing.Size(75, 23);
            this._sword.TabIndex = 1;
            this._sword.Text = "劍兵";
            this._sword.UseVisualStyleBackColor = true;
            this._sword.Click += new System.EventHandler(this.button2_Click);
            // 
            // _arrow
            // 
            this._arrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._arrow.Location = new System.Drawing.Point(98, 212);
            this._arrow.Name = "_arrow";
            this._arrow.Size = new System.Drawing.Size(75, 23);
            this._arrow.TabIndex = 2;
            this._arrow.Text = "弓兵";
            this._arrow.UseVisualStyleBackColor = true;
            this._arrow.Click += new System.EventHandler(this.button3_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 500;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Green;
            this.textBox1.Location = new System.Drawing.Point(17, 183);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            // 
            // _shield
            // 
            this._shield.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._shield.Location = new System.Drawing.Point(179, 212);
            this._shield.Name = "_shield";
            this._shield.Size = new System.Drawing.Size(75, 23);
            this._shield.TabIndex = 4;
            this._shield.Text = "盾牌";
            this._shield.UseVisualStyleBackColor = true;
            this._shield.Click += new System.EventHandler(this.button4_Click);
            // 
            // _rocket
            // 
            this._rocket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._rocket.Location = new System.Drawing.Point(422, 211);
            this._rocket.Name = "_rocket";
            this._rocket.Size = new System.Drawing.Size(75, 23);
            this._rocket.TabIndex = 5;
            this._rocket.Text = "火箭";
            this._rocket.UseVisualStyleBackColor = true;
            this._rocket.Click += new System.EventHandler(this.button5_Click);
            // 
            // _hatchet
            // 
            this._hatchet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._hatchet.Location = new System.Drawing.Point(260, 211);
            this._hatchet.Name = "_hatchet";
            this._hatchet.Size = new System.Drawing.Size(75, 23);
            this._hatchet.TabIndex = 6;
            this._hatchet.Text = "斧手";
            this._hatchet.UseVisualStyleBackColor = true;
            this._hatchet.Click += new System.EventHandler(this.button6_Click);
            // 
            // _wall
            // 
            this._wall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._wall.Location = new System.Drawing.Point(341, 211);
            this._wall.Name = "_wall";
            this._wall.Size = new System.Drawing.Size(75, 23);
            this._wall.TabIndex = 7;
            this._wall.Text = "鐵壁";
            this._wall.UseVisualStyleBackColor = true;
            this._wall.Click += new System.EventHandler(this.button7_Click);
            // 
            // _rescue
            // 
            this._rescue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._rescue.Location = new System.Drawing.Point(503, 211);
            this._rescue.Name = "_rescue";
            this._rescue.Size = new System.Drawing.Size(75, 23);
            this._rescue.TabIndex = 8;
            this._rescue.Text = "醫護";
            this._rescue.UseVisualStyleBackColor = true;
            this._rescue.Click += new System.EventHandler(this.button8_Click);
            // 
            // _restart
            // 
            this._restart.Location = new System.Drawing.Point(204, 181);
            this._restart.Name = "_restart";
            this._restart.Size = new System.Drawing.Size(75, 25);
            this._restart.TabIndex = 9;
            this._restart.Text = "重新開始";
            this._restart.UseVisualStyleBackColor = true;
            this._restart.Click += new System.EventHandler(this._restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(588, 253);
            this.Controls.Add(this._restart);
            this.Controls.Add(this._rescue);
            this.Controls.Add(this._wall);
            this.Controls.Add(this._hatchet);
            this.Controls.Add(this._rocket);
            this.Controls.Add(this._shield);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._arrow);
            this.Controls.Add(this._sword);
            this.Controls.Add(this._start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Little War Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _start;
        private System.Windows.Forms.Button _sword;
        private System.Windows.Forms.Button _arrow;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button _shield;
        private System.Windows.Forms.Button _rocket;
        private System.Windows.Forms.Button _hatchet;
        private System.Windows.Forms.Button _wall;
        private System.Windows.Forms.Button _rescue;
        private System.Windows.Forms.Button _restart;
    }
}

