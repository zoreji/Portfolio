namespace Missle_Command
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.bt_Start = new System.Windows.Forms.Button();
            this.bt_pause = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.CB_difficulty = new System.Windows.Forms.ComboBox();
            this.lb_difficulty = new System.Windows.Forms.Label();
            this.bt_reset = new System.Windows.Forms.Button();
            this.lb_score = new System.Windows.Forms.Label();
            this.lb_kills = new System.Windows.Forms.Label();
            this.lb_lives = new System.Windows.Forms.Label();
            this.lb_incoming = new System.Windows.Forms.Label();
            this.lb_outcoming = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Start
            // 
            this.bt_Start.Location = new System.Drawing.Point(24, 57);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(75, 23);
            this.bt_Start.TabIndex = 0;
            this.bt_Start.Text = "Start";
            this.bt_Start.UseVisualStyleBackColor = true;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // bt_pause
            // 
            this.bt_pause.Location = new System.Drawing.Point(105, 57);
            this.bt_pause.Name = "bt_pause";
            this.bt_pause.Size = new System.Drawing.Size(75, 23);
            this.bt_pause.TabIndex = 1;
            this.bt_pause.Text = "Pause";
            this.bt_pause.UseVisualStyleBackColor = true;
            this.bt_pause.Click += new System.EventHandler(this.bt_pause_Click);
            // 
            // timer
            // 
            this.timer.Interval = 75;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CB_difficulty
            // 
            this.CB_difficulty.FormattingEnabled = true;
            this.CB_difficulty.Location = new System.Drawing.Point(24, 30);
            this.CB_difficulty.Name = "CB_difficulty";
            this.CB_difficulty.Size = new System.Drawing.Size(156, 21);
            this.CB_difficulty.TabIndex = 2;
            this.CB_difficulty.Text = "-Choose Difficulty-";
            // 
            // lb_difficulty
            // 
            this.lb_difficulty.AutoSize = true;
            this.lb_difficulty.Location = new System.Drawing.Point(24, 14);
            this.lb_difficulty.Name = "lb_difficulty";
            this.lb_difficulty.Size = new System.Drawing.Size(47, 13);
            this.lb_difficulty.TabIndex = 3;
            this.lb_difficulty.Text = "Difficulty";
            // 
            // bt_reset
            // 
            this.bt_reset.Location = new System.Drawing.Point(186, 57);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(75, 23);
            this.bt_reset.TabIndex = 4;
            this.bt_reset.Text = "Reset";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // lb_score
            // 
            this.lb_score.AutoSize = true;
            this.lb_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_score.Location = new System.Drawing.Point(20, 131);
            this.lb_score.Name = "lb_score";
            this.lb_score.Size = new System.Drawing.Size(70, 24);
            this.lb_score.TabIndex = 5;
            this.lb_score.Text = "Score :";
            // 
            // lb_kills
            // 
            this.lb_kills.AutoSize = true;
            this.lb_kills.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_kills.Location = new System.Drawing.Point(20, 179);
            this.lb_kills.Name = "lb_kills";
            this.lb_kills.Size = new System.Drawing.Size(58, 24);
            this.lb_kills.TabIndex = 6;
            this.lb_kills.Text = "Kills : ";
            // 
            // lb_lives
            // 
            this.lb_lives.AutoSize = true;
            this.lb_lives.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_lives.Location = new System.Drawing.Point(20, 155);
            this.lb_lives.Name = "lb_lives";
            this.lb_lives.Size = new System.Drawing.Size(68, 24);
            this.lb_lives.TabIndex = 7;
            this.lb_lives.Text = "Lives : ";
            // 
            // lb_incoming
            // 
            this.lb_incoming.AutoSize = true;
            this.lb_incoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_incoming.Location = new System.Drawing.Point(20, 83);
            this.lb_incoming.Name = "lb_incoming";
            this.lb_incoming.Size = new System.Drawing.Size(98, 24);
            this.lb_incoming.TabIndex = 8;
            this.lb_incoming.Text = "Incoming :";
            // 
            // lb_outcoming
            // 
            this.lb_outcoming.AutoSize = true;
            this.lb_outcoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_outcoming.Location = new System.Drawing.Point(20, 107);
            this.lb_outcoming.Name = "lb_outcoming";
            this.lb_outcoming.Size = new System.Drawing.Size(118, 24);
            this.lb_outcoming.TabIndex = 9;
            this.lb_outcoming.Text = "Outcoming : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 228);
            this.Controls.Add(this.lb_outcoming);
            this.Controls.Add(this.lb_incoming);
            this.Controls.Add(this.lb_lives);
            this.Controls.Add(this.lb_kills);
            this.Controls.Add(this.lb_score);
            this.Controls.Add(this.bt_reset);
            this.Controls.Add(this.lb_difficulty);
            this.Controls.Add(this.CB_difficulty);
            this.Controls.Add(this.bt_pause);
            this.Controls.Add(this.bt_Start);
            this.Name = "Form1";
            this.Text = "Missile Command";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Button bt_pause;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox CB_difficulty;
        private System.Windows.Forms.Label lb_difficulty;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.Label lb_score;
        private System.Windows.Forms.Label lb_kills;
        private System.Windows.Forms.Label lb_lives;
        private System.Windows.Forms.Label lb_incoming;
        private System.Windows.Forms.Label lb_outcoming;
    }
}

