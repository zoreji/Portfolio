namespace ICA02_Ervin
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.TB_Opacity = new System.Windows.Forms.TrackBar();
            this.TB_Xvalue = new System.Windows.Forms.TrackBar();
            this.TB_Yvalue = new System.Windows.Forms.TrackBar();
            this.CH_All = new System.Windows.Forms.CheckBox();
            this.Opacity_LB = new System.Windows.Forms.Label();
            this.X_LB = new System.Windows.Forms.Label();
            this.Y_TB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Opacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Xvalue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Yvalue)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // TB_Opacity
            // 
            this.TB_Opacity.Location = new System.Drawing.Point(103, 43);
            this.TB_Opacity.Maximum = 255;
            this.TB_Opacity.Name = "TB_Opacity";
            this.TB_Opacity.Size = new System.Drawing.Size(631, 45);
            this.TB_Opacity.TabIndex = 0;
            this.TB_Opacity.TickFrequency = 5;
            this.TB_Opacity.Scroll += new System.EventHandler(this.TB_Opacity_Scroll);
            // 
            // TB_Xvalue
            // 
            this.TB_Xvalue.Location = new System.Drawing.Point(103, 94);
            this.TB_Xvalue.Maximum = 15;
            this.TB_Xvalue.Minimum = -15;
            this.TB_Xvalue.Name = "TB_Xvalue";
            this.TB_Xvalue.Size = new System.Drawing.Size(631, 45);
            this.TB_Xvalue.TabIndex = 1;
            this.TB_Xvalue.Scroll += new System.EventHandler(this.TB_Xvalue_Scroll);
            // 
            // TB_Yvalue
            // 
            this.TB_Yvalue.Location = new System.Drawing.Point(103, 145);
            this.TB_Yvalue.Maximum = 15;
            this.TB_Yvalue.Minimum = -15;
            this.TB_Yvalue.Name = "TB_Yvalue";
            this.TB_Yvalue.Size = new System.Drawing.Size(631, 45);
            this.TB_Yvalue.TabIndex = 2;
            this.TB_Yvalue.Scroll += new System.EventHandler(this.TB_Yvalue_Scroll);
            // 
            // CH_All
            // 
            this.CH_All.AutoSize = true;
            this.CH_All.Location = new System.Drawing.Point(103, 196);
            this.CH_All.Name = "CH_All";
            this.CH_All.Size = new System.Drawing.Size(37, 17);
            this.CH_All.TabIndex = 3;
            this.CH_All.Text = "All";
            this.CH_All.UseVisualStyleBackColor = true;
            // 
            // Opacity_LB
            // 
            this.Opacity_LB.AutoSize = true;
            this.Opacity_LB.Location = new System.Drawing.Point(32, 43);
            this.Opacity_LB.Name = "Opacity_LB";
            this.Opacity_LB.Size = new System.Drawing.Size(49, 13);
            this.Opacity_LB.TabIndex = 4;
            this.Opacity_LB.Text = "Opacity :";
            // 
            // X_LB
            // 
            this.X_LB.AutoSize = true;
            this.X_LB.Location = new System.Drawing.Point(32, 94);
            this.X_LB.Name = "X_LB";
            this.X_LB.Size = new System.Drawing.Size(23, 13);
            this.X_LB.TabIndex = 5;
            this.X_LB.Tag = "";
            this.X_LB.Text = "X : ";
            // 
            // Y_TB
            // 
            this.Y_TB.AutoSize = true;
            this.Y_TB.Location = new System.Drawing.Point(32, 145);
            this.Y_TB.Name = "Y_TB";
            this.Y_TB.Size = new System.Drawing.Size(23, 13);
            this.Y_TB.TabIndex = 6;
            this.Y_TB.Text = "Y : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 262);
            this.Controls.Add(this.Y_TB);
            this.Controls.Add(this.X_LB);
            this.Controls.Add(this.Opacity_LB);
            this.Controls.Add(this.CH_All);
            this.Controls.Add(this.TB_Yvalue);
            this.Controls.Add(this.TB_Xvalue);
            this.Controls.Add(this.TB_Opacity);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TB_Opacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Xvalue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Yvalue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TrackBar TB_Opacity;
        private System.Windows.Forms.TrackBar TB_Xvalue;
        private System.Windows.Forms.TrackBar TB_Yvalue;
        private System.Windows.Forms.CheckBox CH_All;
        private System.Windows.Forms.Label Opacity_LB;
        private System.Windows.Forms.Label X_LB;
        private System.Windows.Forms.Label Y_TB;
    }
}

