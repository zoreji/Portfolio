namespace A05Ervin
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
            this.TB_Size = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Add = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.BT_ClearBall = new System.Windows.Forms.Button();
            this.RB_Radius = new System.Windows.Forms.RadioButton();
            this.RB_Color = new System.Windows.Forms.RadioButton();
            this.RB_Distance = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Size)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Size
            // 
            this.TB_Size.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Size.Location = new System.Drawing.Point(12, 12);
            this.TB_Size.Maximum = 50;
            this.TB_Size.Minimum = -50;
            this.TB_Size.Name = "TB_Size";
            this.TB_Size.Size = new System.Drawing.Size(454, 45);
            this.TB_Size.TabIndex = 0;
            this.TB_Size.TickFrequency = 5;
            this.TB_Size.Scroll += new System.EventHandler(this.TB_Size_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // BT_Add
            // 
            this.BT_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Add.Location = new System.Drawing.Point(12, 100);
            this.BT_Add.Name = "BT_Add";
            this.BT_Add.Size = new System.Drawing.Size(208, 52);
            this.BT_Add.TabIndex = 2;
            this.BT_Add.Text = "ADD";
            this.BT_Add.UseVisualStyleBackColor = true;
            this.BT_Add.Click += new System.EventHandler(this.BT_Add_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 225);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(454, 26);
            this.progressBar.TabIndex = 3;
            // 
            // BT_ClearBall
            // 
            this.BT_ClearBall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_ClearBall.Location = new System.Drawing.Point(247, 100);
            this.BT_ClearBall.Name = "BT_ClearBall";
            this.BT_ClearBall.Size = new System.Drawing.Size(215, 52);
            this.BT_ClearBall.TabIndex = 4;
            this.BT_ClearBall.Text = "Clear Balls";
            this.BT_ClearBall.UseVisualStyleBackColor = true;
            this.BT_ClearBall.Click += new System.EventHandler(this.BT_ClearBall_Click);
            // 
            // RB_Radius
            // 
            this.RB_Radius.AutoSize = true;
            this.RB_Radius.Checked = true;
            this.RB_Radius.Location = new System.Drawing.Point(53, 19);
            this.RB_Radius.Name = "RB_Radius";
            this.RB_Radius.Size = new System.Drawing.Size(58, 17);
            this.RB_Radius.TabIndex = 5;
            this.RB_Radius.TabStop = true;
            this.RB_Radius.Text = "Radius";
            this.RB_Radius.UseVisualStyleBackColor = true;
            this.RB_Radius.Click += new System.EventHandler(this.RB_Radius_Click);
            // 
            // RB_Color
            // 
            this.RB_Color.AutoSize = true;
            this.RB_Color.Location = new System.Drawing.Point(235, 19);
            this.RB_Color.Name = "RB_Color";
            this.RB_Color.Size = new System.Drawing.Size(49, 17);
            this.RB_Color.TabIndex = 6;
            this.RB_Color.Text = "Color";
            this.RB_Color.UseVisualStyleBackColor = true;
            this.RB_Color.Click += new System.EventHandler(this.RB_Radius_Click);
            // 
            // RB_Distance
            // 
            this.RB_Distance.AutoSize = true;
            this.RB_Distance.Location = new System.Drawing.Point(144, 19);
            this.RB_Distance.Name = "RB_Distance";
            this.RB_Distance.Size = new System.Drawing.Size(67, 17);
            this.RB_Distance.TabIndex = 7;
            this.RB_Distance.Text = "Distance";
            this.RB_Distance.UseVisualStyleBackColor = true;
            this.RB_Distance.Click += new System.EventHandler(this.RB_Radius_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.RB_Radius);
            this.groupBox1.Controls.Add(this.RB_Distance);
            this.groupBox1.Controls.Add(this.RB_Color);
            this.groupBox1.Location = new System.Drawing.Point(12, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 59);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 264);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BT_ClearBall);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.BT_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Size);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TB_Size)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TB_Size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Add;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button BT_ClearBall;
        private System.Windows.Forms.RadioButton RB_Radius;
        private System.Windows.Forms.RadioButton RB_Color;
        private System.Windows.Forms.RadioButton RB_Distance;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

