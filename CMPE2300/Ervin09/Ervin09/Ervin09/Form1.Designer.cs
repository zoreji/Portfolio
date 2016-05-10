namespace Ervin09
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
            this.bt_makeList = new System.Windows.Forms.Button();
            this.bt_populate = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_makeList
            // 
            this.bt_makeList.Location = new System.Drawing.Point(12, 38);
            this.bt_makeList.Name = "bt_makeList";
            this.bt_makeList.Size = new System.Drawing.Size(189, 23);
            this.bt_makeList.TabIndex = 0;
            this.bt_makeList.Text = "Make List";
            this.bt_makeList.UseVisualStyleBackColor = true;
            this.bt_makeList.Click += new System.EventHandler(this.bt_makeList_Click);
            // 
            // bt_populate
            // 
            this.bt_populate.Location = new System.Drawing.Point(12, 67);
            this.bt_populate.Name = "bt_populate";
            this.bt_populate.Size = new System.Drawing.Size(189, 23);
            this.bt_populate.TabIndex = 1;
            this.bt_populate.Text = "Populate Linked List";
            this.bt_populate.UseVisualStyleBackColor = true;
            this.bt_populate.Click += new System.EventHandler(this.bt_populate_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(12, 12);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(189, 20);
            this.numericUpDown.TabIndex = 2;
            this.numericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 108);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.bt_populate);
            this.Controls.Add(this.bt_makeList);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_makeList;
        private System.Windows.Forms.Button bt_populate;
        private System.Windows.Forms.NumericUpDown numericUpDown;
    }
}

