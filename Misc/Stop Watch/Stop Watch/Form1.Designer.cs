namespace Stop_Watch
{
    partial class Stop_Watch_Form
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
            this.StartBT = new System.Windows.Forms.Button();
            this.StopBT = new System.Windows.Forms.Button();
            this.ResetBT = new System.Windows.Forms.Button();
            this.MinTB = new System.Windows.Forms.TextBox();
            this.mSecTB = new System.Windows.Forms.TextBox();
            this.SecTB = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StartBT
            // 
            this.StartBT.Location = new System.Drawing.Point(81, 98);
            this.StartBT.Name = "StartBT";
            this.StartBT.Size = new System.Drawing.Size(75, 23);
            this.StartBT.TabIndex = 0;
            this.StartBT.Text = "Start";
            this.StartBT.UseVisualStyleBackColor = true;
            this.StartBT.Click += new System.EventHandler(this.StartBT_Click);
            // 
            // StopBT
            // 
            this.StopBT.Location = new System.Drawing.Point(162, 98);
            this.StopBT.Name = "StopBT";
            this.StopBT.Size = new System.Drawing.Size(75, 23);
            this.StopBT.TabIndex = 1;
            this.StopBT.Text = "Stop";
            this.StopBT.UseVisualStyleBackColor = true;
            this.StopBT.Click += new System.EventHandler(this.StopBT_Click);
            // 
            // ResetBT
            // 
            this.ResetBT.Location = new System.Drawing.Point(243, 98);
            this.ResetBT.Name = "ResetBT";
            this.ResetBT.Size = new System.Drawing.Size(75, 23);
            this.ResetBT.TabIndex = 2;
            this.ResetBT.Text = "Reset";
            this.ResetBT.UseVisualStyleBackColor = true;
            this.ResetBT.Click += new System.EventHandler(this.ResetBT_Click);
            // 
            // MinTB
            // 
            this.MinTB.Location = new System.Drawing.Point(81, 72);
            this.MinTB.Name = "MinTB";
            this.MinTB.ReadOnly = true;
            this.MinTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MinTB.Size = new System.Drawing.Size(75, 20);
            this.MinTB.TabIndex = 3;
            this.MinTB.TabStop = false;
            // 
            // mSecTB
            // 
            this.mSecTB.Location = new System.Drawing.Point(243, 72);
            this.mSecTB.Name = "mSecTB";
            this.mSecTB.ReadOnly = true;
            this.mSecTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mSecTB.Size = new System.Drawing.Size(75, 20);
            this.mSecTB.TabIndex = 5;
            this.mSecTB.TabStop = false;
            // 
            // SecTB
            // 
            this.SecTB.Location = new System.Drawing.Point(162, 72);
            this.SecTB.Name = "SecTB";
            this.SecTB.ReadOnly = true;
            this.SecTB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SecTB.Size = new System.Drawing.Size(75, 20);
            this.SecTB.TabIndex = 4;
            this.SecTB.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Stop_Watch_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(399, 192);
            this.Controls.Add(this.SecTB);
            this.Controls.Add(this.mSecTB);
            this.Controls.Add(this.MinTB);
            this.Controls.Add(this.ResetBT);
            this.Controls.Add(this.StopBT);
            this.Controls.Add(this.StartBT);
            this.MaximumSize = new System.Drawing.Size(415, 230);
            this.MinimumSize = new System.Drawing.Size(415, 230);
            this.Name = "Stop_Watch_Form";
            this.Text = "Stop Watch";
            this.Load += new System.EventHandler(this.Stop_Watch_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBT;
        private System.Windows.Forms.Button StopBT;
        private System.Windows.Forms.Button ResetBT;
        private System.Windows.Forms.TextBox MinTB;
        private System.Windows.Forms.TextBox mSecTB;
        private System.Windows.Forms.TextBox SecTB;
        private System.Windows.Forms.Timer timer1;
    }
}

