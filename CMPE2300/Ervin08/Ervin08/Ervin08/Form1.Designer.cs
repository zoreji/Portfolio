namespace Ervin08
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.bt_simulate = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 47);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(130, 355);
            this.listBox.TabIndex = 0;
            // 
            // bt_simulate
            // 
            this.bt_simulate.Location = new System.Drawing.Point(12, 12);
            this.bt_simulate.Name = "bt_simulate";
            this.bt_simulate.Size = new System.Drawing.Size(75, 23);
            this.bt_simulate.TabIndex = 1;
            this.bt_simulate.Text = "Simulate";
            this.bt_simulate.UseVisualStyleBackColor = true;
            this.bt_simulate.Click += new System.EventHandler(this.bt_simulate_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(102, 15);
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown.TabIndex = 2;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 423);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.bt_simulate);
            this.Controls.Add(this.listBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button bt_simulate;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Timer timer;
    }
}

