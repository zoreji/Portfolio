namespace ShippingForm
{
    partial class Shipping_Form
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
            this.Amount_TB = new System.Windows.Forms.TextBox();
            this.Total_TB = new System.Windows.Forms.TextBox();
            this.ShippingGB = new System.Windows.Forms.GroupBox();
            this.Express_RB = new System.Windows.Forms.RadioButton();
            this.Free_RB = new System.Windows.Forms.RadioButton();
            this.InsuranceGB = new System.Windows.Forms.GroupBox();
            this.Gold_RB = new System.Windows.Forms.RadioButton();
            this.None_RB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TaxCB = new System.Windows.Forms.CheckBox();
            this.ShippingGB.SuspendLayout();
            this.InsuranceGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Amount_TB
            // 
            this.Amount_TB.Location = new System.Drawing.Point(137, 12);
            this.Amount_TB.Name = "Amount_TB";
            this.Amount_TB.Size = new System.Drawing.Size(100, 20);
            this.Amount_TB.TabIndex = 0;
            this.Amount_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount_TB.TextChanged += new System.EventHandler(this.Amount_TB_TextChanged);
            // 
            // Total_TB
            // 
            this.Total_TB.Location = new System.Drawing.Point(137, 173);
            this.Total_TB.Name = "Total_TB";
            this.Total_TB.ReadOnly = true;
            this.Total_TB.Size = new System.Drawing.Size(100, 20);
            this.Total_TB.TabIndex = 1;
            this.Total_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ShippingGB
            // 
            this.ShippingGB.Controls.Add(this.Express_RB);
            this.ShippingGB.Controls.Add(this.Free_RB);
            this.ShippingGB.Location = new System.Drawing.Point(11, 56);
            this.ShippingGB.Name = "ShippingGB";
            this.ShippingGB.Size = new System.Drawing.Size(128, 111);
            this.ShippingGB.TabIndex = 2;
            this.ShippingGB.TabStop = false;
            this.ShippingGB.Text = "Shipping";
            // 
            // Express_RB
            // 
            this.Express_RB.AutoSize = true;
            this.Express_RB.Checked = true;
            this.Express_RB.Location = new System.Drawing.Point(20, 58);
            this.Express_RB.Name = "Express_RB";
            this.Express_RB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Express_RB.Size = new System.Drawing.Size(89, 17);
            this.Express_RB.TabIndex = 1;
            this.Express_RB.TabStop = true;
            this.Express_RB.Text = "Express - $20";
            this.Express_RB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Express_RB.UseVisualStyleBackColor = true;
            this.Express_RB.CheckedChanged += new System.EventHandler(this.Amount_TB_TextChanged);
            // 
            // Free_RB
            // 
            this.Free_RB.AutoSize = true;
            this.Free_RB.Location = new System.Drawing.Point(63, 35);
            this.Free_RB.Name = "Free_RB";
            this.Free_RB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Free_RB.Size = new System.Drawing.Size(46, 17);
            this.Free_RB.TabIndex = 0;
            this.Free_RB.Text = "Free";
            this.Free_RB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Free_RB.UseVisualStyleBackColor = true;
            this.Free_RB.CheckedChanged += new System.EventHandler(this.Amount_TB_TextChanged);
            // 
            // InsuranceGB
            // 
            this.InsuranceGB.Controls.Add(this.Gold_RB);
            this.InsuranceGB.Controls.Add(this.None_RB);
            this.InsuranceGB.Location = new System.Drawing.Point(145, 56);
            this.InsuranceGB.Name = "InsuranceGB";
            this.InsuranceGB.Size = new System.Drawing.Size(128, 111);
            this.InsuranceGB.TabIndex = 3;
            this.InsuranceGB.TabStop = false;
            this.InsuranceGB.Text = "Insurance";
            // 
            // Gold_RB
            // 
            this.Gold_RB.AutoSize = true;
            this.Gold_RB.Checked = true;
            this.Gold_RB.Location = new System.Drawing.Point(22, 58);
            this.Gold_RB.Name = "Gold_RB";
            this.Gold_RB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Gold_RB.Size = new System.Drawing.Size(70, 17);
            this.Gold_RB.TabIndex = 1;
            this.Gold_RB.TabStop = true;
            this.Gold_RB.Text = "Gold - 5%";
            this.Gold_RB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Gold_RB.UseVisualStyleBackColor = true;
            this.Gold_RB.CheckedChanged += new System.EventHandler(this.Amount_TB_TextChanged);
            // 
            // None_RB
            // 
            this.None_RB.AutoSize = true;
            this.None_RB.Location = new System.Drawing.Point(41, 35);
            this.None_RB.Name = "None_RB";
            this.None_RB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.None_RB.Size = new System.Drawing.Size(51, 17);
            this.None_RB.TabIndex = 0;
            this.None_RB.Text = "None";
            this.None_RB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.None_RB.UseVisualStyleBackColor = true;
            this.None_RB.CheckedChanged += new System.EventHandler(this.Amount_TB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Amount";
            // 
            // TaxCB
            // 
            this.TaxCB.AutoSize = true;
            this.TaxCB.Checked = true;
            this.TaxCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TaxCB.Location = new System.Drawing.Point(155, 38);
            this.TaxCB.Name = "TaxCB";
            this.TaxCB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TaxCB.Size = new System.Drawing.Size(82, 17);
            this.TaxCB.TabIndex = 6;
            this.TaxCB.Text = "Tax Exempt";
            this.TaxCB.UseVisualStyleBackColor = true;
            this.TaxCB.CheckedChanged += new System.EventHandler(this.Amount_TB_TextChanged);
            // 
            // Shipping_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.Controls.Add(this.TaxCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InsuranceGB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShippingGB);
            this.Controls.Add(this.Total_TB);
            this.Controls.Add(this.Amount_TB);
            this.MaximumSize = new System.Drawing.Size(300, 260);
            this.MinimumSize = new System.Drawing.Size(300, 260);
            this.Name = "Shipping_Form";
            this.Text = "Shipping Application";
            this.Load += new System.EventHandler(this.Shipping_Form_Load);
            this.ShippingGB.ResumeLayout(false);
            this.ShippingGB.PerformLayout();
            this.InsuranceGB.ResumeLayout(false);
            this.InsuranceGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Amount_TB;
        private System.Windows.Forms.TextBox Total_TB;
        private System.Windows.Forms.GroupBox ShippingGB;
        private System.Windows.Forms.GroupBox InsuranceGB;
        private System.Windows.Forms.RadioButton Express_RB;
        private System.Windows.Forms.RadioButton Free_RB;
        private System.Windows.Forms.RadioButton Gold_RB;
        private System.Windows.Forms.RadioButton None_RB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox TaxCB;
    }
}

