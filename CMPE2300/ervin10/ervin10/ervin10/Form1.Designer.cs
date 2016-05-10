namespace ervin10
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
            this.BT_Load = new System.Windows.Forms.Button();
            this.LV_dictionary = new System.Windows.Forms.ListView();
            this.H_KeyWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.H_Frequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BT_Load
            // 
            this.BT_Load.Location = new System.Drawing.Point(12, 12);
            this.BT_Load.Name = "BT_Load";
            this.BT_Load.Size = new System.Drawing.Size(453, 41);
            this.BT_Load.TabIndex = 0;
            this.BT_Load.Text = "Load";
            this.BT_Load.UseVisualStyleBackColor = true;
            this.BT_Load.Click += new System.EventHandler(this.BT_Load_Click);
            this.BT_Load.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BT_Load_KeyDown);
            // 
            // LV_dictionary
            // 
            this.LV_dictionary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.H_KeyWord,
            this.H_Frequency});
            this.LV_dictionary.GridLines = true;
            this.LV_dictionary.Location = new System.Drawing.Point(12, 59);
            this.LV_dictionary.Name = "LV_dictionary";
            this.LV_dictionary.Size = new System.Drawing.Size(453, 440);
            this.LV_dictionary.TabIndex = 1;
            this.LV_dictionary.UseCompatibleStateImageBehavior = false;
            this.LV_dictionary.View = System.Windows.Forms.View.Details;
            // 
            // H_KeyWord
            // 
            this.H_KeyWord.Text = "KeyWord";
            this.H_KeyWord.Width = 128;
            // 
            // H_Frequency
            // 
            this.H_Frequency.Text = "Frequency";
            this.H_Frequency.Width = 264;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 511);
            this.Controls.Add(this.LV_dictionary);
            this.Controls.Add(this.BT_Load);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_Load;
        private System.Windows.Forms.ListView LV_dictionary;
        private System.Windows.Forms.ColumnHeader H_KeyWord;
        private System.Windows.Forms.ColumnHeader H_Frequency;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

