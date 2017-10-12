namespace LittleWarGame
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._startNewGame = new System.Windows.Forms.Button();
            this._loadGame = new System.Windows.Forms.Button();
            this._about = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _startNewGame
            // 
            this._startNewGame.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._startNewGame.Location = new System.Drawing.Point(171, 64);
            this._startNewGame.Name = "_startNewGame";
            this._startNewGame.Size = new System.Drawing.Size(120, 40);
            this._startNewGame.TabIndex = 0;
            this._startNewGame.Text = "新遊戲";
            this._startNewGame.UseVisualStyleBackColor = true;
            this._startNewGame.Click += new System.EventHandler(this._startNewGame_Click);
            // 
            // _loadGame
            // 
            this._loadGame.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._loadGame.Location = new System.Drawing.Point(171, 110);
            this._loadGame.Name = "_loadGame";
            this._loadGame.Size = new System.Drawing.Size(120, 40);
            this._loadGame.TabIndex = 1;
            this._loadGame.Text = "讀取進度";
            this._loadGame.UseVisualStyleBackColor = true;
            this._loadGame.Click += new System.EventHandler(this._loadGame_Click);
            // 
            // _about
            // 
            this._about.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._about.Location = new System.Drawing.Point(171, 156);
            this._about.Name = "_about";
            this._about.Size = new System.Drawing.Size(120, 40);
            this._about.TabIndex = 2;
            this._about.Text = "關於";
            this._about.UseVisualStyleBackColor = true;
            this._about.Click += new System.EventHandler(this._about_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 241);
            this.Controls.Add(this._about);
            this.Controls.Add(this._loadGame);
            this.Controls.Add(this._startNewGame);
            this.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小小戰爭";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _startNewGame;
        private System.Windows.Forms.Button _loadGame;
        private System.Windows.Forms.Button _about;
    }
}