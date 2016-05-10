namespace A04Ervin
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
            ((System.ComponentModel.ISupportInitialize)(this.TB_Size)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_Size
            // 
            this.TB_Size.Location = new System.Drawing.Point(12, 12);
            this.TB_Size.Maximum = 50;
            this.TB_Size.Minimum = -50;
            this.TB_Size.Name = "TB_Size";
            this.TB_Size.Size = new System.Drawing.Size(679, 45);
            this.TB_Size.TabIndex = 0;
            this.TB_Size.TickFrequency = 5;
            this.TB_Size.Scroll += new System.EventHandler(this.TB_Size_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // BT_Add
            // 
            this.BT_Add.Location = new System.Drawing.Point(12, 110);
            this.BT_Add.Name = "BT_Add";
            this.BT_Add.Size = new System.Drawing.Size(679, 110);
            this.BT_Add.TabIndex = 2;
            this.BT_Add.Text = "ADD";
            this.BT_Add.UseVisualStyleBackColor = true;
            this.BT_Add.Click += new System.EventHandler(this.BT_Add_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 226);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(679, 23);
            this.progressBar.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 261);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.BT_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Size);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TB_Size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TB_Size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Add;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

