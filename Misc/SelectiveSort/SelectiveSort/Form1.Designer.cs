namespace SelectiveSort
{
    partial class Sort_Main_Form
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
            this.SortGroup_GB = new System.Windows.Forms.GroupBox();
            this.Reset_BT = new System.Windows.Forms.Button();
            this.Sort_BT = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Generate_BT = new System.Windows.Forms.Button();
            this.SortGroup_GB.SuspendLayout();
            this.SuspendLayout();
            // 
            // SortGroup_GB
            // 
            this.SortGroup_GB.Controls.Add(this.Generate_BT);
            this.SortGroup_GB.Controls.Add(this.Reset_BT);
            this.SortGroup_GB.Controls.Add(this.Sort_BT);
            this.SortGroup_GB.Controls.Add(this.listBox1);
            this.SortGroup_GB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SortGroup_GB.Location = new System.Drawing.Point(0, 0);
            this.SortGroup_GB.Name = "SortGroup_GB";
            this.SortGroup_GB.Size = new System.Drawing.Size(224, 222);
            this.SortGroup_GB.TabIndex = 0;
            this.SortGroup_GB.TabStop = false;
            this.SortGroup_GB.Text = "Sort";
            // 
            // Reset_BT
            // 
            this.Reset_BT.Location = new System.Drawing.Point(138, 77);
            this.Reset_BT.Name = "Reset_BT";
            this.Reset_BT.Size = new System.Drawing.Size(66, 23);
            this.Reset_BT.TabIndex = 5;
            this.Reset_BT.Text = "Reset";
            this.Reset_BT.UseVisualStyleBackColor = true;
            this.Reset_BT.Click += new System.EventHandler(this.Reset_BT_Click);
            // 
            // Sort_BT
            // 
            this.Sort_BT.Location = new System.Drawing.Point(138, 48);
            this.Sort_BT.Name = "Sort_BT";
            this.Sort_BT.Size = new System.Drawing.Size(66, 23);
            this.Sort_BT.TabIndex = 3;
            this.Sort_BT.Text = "Sort";
            this.Sort_BT.UseVisualStyleBackColor = true;
            this.Sort_BT.Click += new System.EventHandler(this.Sort_BT_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 173);
            this.listBox1.TabIndex = 0;
            // 
            // Generate_BT
            // 
            this.Generate_BT.Location = new System.Drawing.Point(138, 19);
            this.Generate_BT.Name = "Generate_BT";
            this.Generate_BT.Size = new System.Drawing.Size(66, 23);
            this.Generate_BT.TabIndex = 6;
            this.Generate_BT.Text = "Generate";
            this.Generate_BT.UseVisualStyleBackColor = true;
            this.Generate_BT.Click += new System.EventHandler(this.Generate_BT_Click);
            // 
            // Sort_Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 222);
            this.Controls.Add(this.SortGroup_GB);
            this.MinimumSize = new System.Drawing.Size(240, 260);
            this.Name = "Sort_Main_Form";
            this.Text = "Selective Sorting";
            this.SortGroup_GB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SortGroup_GB;
        private System.Windows.Forms.Button Sort_BT;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Reset_BT;
        private System.Windows.Forms.Button Generate_BT;
    }
}

