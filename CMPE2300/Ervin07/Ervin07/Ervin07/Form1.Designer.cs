namespace Ervin07
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
            this.bt_populate = new System.Windows.Forms.Button();
            this.bt_color = new System.Windows.Forms.Button();
            this.bt_width = new System.Windows.Forms.Button();
            this.bt_widthDesc = new System.Windows.Forms.Button();
            this.bt_widthColor = new System.Windows.Forms.Button();
            this.bt_bright = new System.Windows.Forms.Button();
            this.bt_longer100 = new System.Windows.Forms.Button();
            this.tb_bar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tb_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_populate
            // 
            this.bt_populate.Location = new System.Drawing.Point(12, 12);
            this.bt_populate.Name = "bt_populate";
            this.bt_populate.Size = new System.Drawing.Size(218, 23);
            this.bt_populate.TabIndex = 0;
            this.bt_populate.Text = "Populate";
            this.bt_populate.UseVisualStyleBackColor = true;
            this.bt_populate.Click += new System.EventHandler(this.bt_populate_Click);
            // 
            // bt_color
            // 
            this.bt_color.Location = new System.Drawing.Point(12, 41);
            this.bt_color.Name = "bt_color";
            this.bt_color.Size = new System.Drawing.Size(218, 23);
            this.bt_color.TabIndex = 1;
            this.bt_color.Text = "Color";
            this.bt_color.UseVisualStyleBackColor = true;
            this.bt_color.Click += new System.EventHandler(this.bt_color_Click);
            // 
            // bt_width
            // 
            this.bt_width.Location = new System.Drawing.Point(12, 70);
            this.bt_width.Name = "bt_width";
            this.bt_width.Size = new System.Drawing.Size(218, 23);
            this.bt_width.TabIndex = 2;
            this.bt_width.Text = "Width";
            this.bt_width.UseVisualStyleBackColor = true;
            this.bt_width.Click += new System.EventHandler(this.bt_width_Click);
            // 
            // bt_widthDesc
            // 
            this.bt_widthDesc.Location = new System.Drawing.Point(12, 99);
            this.bt_widthDesc.Name = "bt_widthDesc";
            this.bt_widthDesc.Size = new System.Drawing.Size(218, 23);
            this.bt_widthDesc.TabIndex = 3;
            this.bt_widthDesc.Text = "Width Desc";
            this.bt_widthDesc.UseVisualStyleBackColor = true;
            this.bt_widthDesc.Click += new System.EventHandler(this.bt_widthDesc_Click);
            // 
            // bt_widthColor
            // 
            this.bt_widthColor.Location = new System.Drawing.Point(12, 128);
            this.bt_widthColor.Name = "bt_widthColor";
            this.bt_widthColor.Size = new System.Drawing.Size(218, 23);
            this.bt_widthColor.TabIndex = 4;
            this.bt_widthColor.Text = "Width / Color";
            this.bt_widthColor.UseVisualStyleBackColor = true;
            this.bt_widthColor.Click += new System.EventHandler(this.bt_widthColor_Click);
            // 
            // bt_bright
            // 
            this.bt_bright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_bright.Location = new System.Drawing.Point(12, 157);
            this.bt_bright.Name = "bt_bright";
            this.bt_bright.Size = new System.Drawing.Size(218, 23);
            this.bt_bright.TabIndex = 5;
            this.bt_bright.Text = "Remove Bright";
            this.bt_bright.UseVisualStyleBackColor = true;
            this.bt_bright.Click += new System.EventHandler(this.bt_bright_Click);
            // 
            // bt_longer100
            // 
            this.bt_longer100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_longer100.Location = new System.Drawing.Point(12, 186);
            this.bt_longer100.Name = "bt_longer100";
            this.bt_longer100.Size = new System.Drawing.Size(218, 23);
            this.bt_longer100.TabIndex = 6;
            this.bt_longer100.Text = " RemoveLonger than 100";
            this.bt_longer100.UseVisualStyleBackColor = true;
            this.bt_longer100.Click += new System.EventHandler(this.bt_longer100_Click);
            // 
            // tb_bar
            // 
            this.tb_bar.Location = new System.Drawing.Point(12, 215);
            this.tb_bar.Maximum = 190;
            this.tb_bar.Minimum = 10;
            this.tb_bar.Name = "tb_bar";
            this.tb_bar.Size = new System.Drawing.Size(218, 45);
            this.tb_bar.TabIndex = 7;
            this.tb_bar.TickFrequency = 10;
            this.tb_bar.Value = 100;
            this.tb_bar.Scroll += new System.EventHandler(this.tb_bar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 305);
            this.Controls.Add(this.tb_bar);
            this.Controls.Add(this.bt_longer100);
            this.Controls.Add(this.bt_bright);
            this.Controls.Add(this.bt_widthColor);
            this.Controls.Add(this.bt_widthDesc);
            this.Controls.Add(this.bt_width);
            this.Controls.Add(this.bt_color);
            this.Controls.Add(this.bt_populate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.tb_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_populate;
        private System.Windows.Forms.Button bt_color;
        private System.Windows.Forms.Button bt_width;
        private System.Windows.Forms.Button bt_widthDesc;
        private System.Windows.Forms.Button bt_widthColor;
        private System.Windows.Forms.Button bt_bright;
        private System.Windows.Forms.Button bt_longer100;
        private System.Windows.Forms.TrackBar tb_bar;
    }
}

