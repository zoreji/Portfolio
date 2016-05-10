namespace ehernandezLab01
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
            this.OFD_LoadPic = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LoadImage_TL = new System.Windows.Forms.ToolStripLabel();
            this.Encode_TL = new System.Windows.Forms.ToolStripLabel();
            this.Decode_TL = new System.Windows.Forms.ToolStripLabel();
            this.Decode_Image_LB = new System.Windows.Forms.ToolStripLabel();
            this.Decode_Image_CB = new System.Windows.Forms.ToolStripComboBox();
            this.PicBox_main = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_main)).BeginInit();
            this.SuspendLayout();
            // 
            // OFD_LoadPic
            // 
            this.OFD_LoadPic.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadImage_TL,
            this.Encode_TL,
            this.Decode_TL,
            this.Decode_Image_LB,
            this.Decode_Image_CB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LoadImage_TL
            // 
            this.LoadImage_TL.Name = "LoadImage_TL";
            this.LoadImage_TL.Size = new System.Drawing.Size(69, 22);
            this.LoadImage_TL.Text = "Load Image";
            this.LoadImage_TL.Click += new System.EventHandler(this.LoadImage_TL_Click);
            // 
            // Encode_TL
            // 
            this.Encode_TL.Name = "Encode_TL";
            this.Encode_TL.Size = new System.Drawing.Size(46, 22);
            this.Encode_TL.Text = "Encode";
            // 
            // Decode_TL
            // 
            this.Decode_TL.Name = "Decode_TL";
            this.Decode_TL.Size = new System.Drawing.Size(47, 22);
            this.Decode_TL.Text = "Decode";
            this.Decode_TL.Click += new System.EventHandler(this.Decode_TL_Click);
            // 
            // Decode_Image_LB
            // 
            this.Decode_Image_LB.Name = "Decode_Image_LB";
            this.Decode_Image_LB.Size = new System.Drawing.Size(83, 22);
            this.Decode_Image_LB.Text = "Decode Image";
            // 
            // Decode_Image_CB
            // 
            this.Decode_Image_CB.Name = "Decode_Image_CB";
            this.Decode_Image_CB.Size = new System.Drawing.Size(121, 25);
            // 
            // PicBox_main
            // 
            this.PicBox_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicBox_main.Location = new System.Drawing.Point(12, 28);
            this.PicBox_main.Name = "PicBox_main";
            this.PicBox_main.Size = new System.Drawing.Size(772, 562);
            this.PicBox_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicBox_main.TabIndex = 1;
            this.PicBox_main.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 602);
            this.Controls.Add(this.PicBox_main);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OFD_LoadPic;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel LoadImage_TL;
        private System.Windows.Forms.ToolStripLabel Encode_TL;
        private System.Windows.Forms.ToolStripLabel Decode_TL;
        private System.Windows.Forms.ToolStripLabel Decode_Image_LB;
        private System.Windows.Forms.ToolStripComboBox Decode_Image_CB;
        private System.Windows.Forms.PictureBox PicBox_main;
    }
}

