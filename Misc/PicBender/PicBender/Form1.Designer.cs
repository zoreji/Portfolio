namespace PicBender
{
    partial class PicBen_Main
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
            this.PicBox_Main = new System.Windows.Forms.PictureBox();
            this.GB_Mod = new System.Windows.Forms.GroupBox();
            this.RB_Noise = new System.Windows.Forms.RadioButton();
            this.RB_Tint = new System.Windows.Forms.RadioButton();
            this.RB_Blk_Wht = new System.Windows.Forms.RadioButton();
            this.RB_Contrast = new System.Windows.Forms.RadioButton();
            this.BT_Load = new System.Windows.Forms.Button();
            this.PB_LoadBar = new System.Windows.Forms.ProgressBar();
            this.TB_Mod = new System.Windows.Forms.TrackBar();
            this.BT_Transform = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Main)).BeginInit();
            this.GB_Mod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Mod)).BeginInit();
            this.SuspendLayout();
            // 
            // OFD_LoadPic
            // 
            this.OFD_LoadPic.FileName = "openFileDialog1";
            this.OFD_LoadPic.Filter = "JEPG|*.jpg|Bit File|*.bmp|All Files|*.*";
            // 
            // PicBox_Main
            // 
            this.PicBox_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox_Main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicBox_Main.Location = new System.Drawing.Point(12, 12);
            this.PicBox_Main.Name = "PicBox_Main";
            this.PicBox_Main.Size = new System.Drawing.Size(770, 445);
            this.PicBox_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox_Main.TabIndex = 0;
            this.PicBox_Main.TabStop = false;
            // 
            // GB_Mod
            // 
            this.GB_Mod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GB_Mod.Controls.Add(this.RB_Noise);
            this.GB_Mod.Controls.Add(this.RB_Tint);
            this.GB_Mod.Controls.Add(this.RB_Blk_Wht);
            this.GB_Mod.Controls.Add(this.RB_Contrast);
            this.GB_Mod.Location = new System.Drawing.Point(113, 481);
            this.GB_Mod.Name = "GB_Mod";
            this.GB_Mod.Size = new System.Drawing.Size(205, 89);
            this.GB_Mod.TabIndex = 1;
            this.GB_Mod.TabStop = false;
            this.GB_Mod.Text = "Modification Type";
            // 
            // RB_Noise
            // 
            this.RB_Noise.AutoSize = true;
            this.RB_Noise.Location = new System.Drawing.Point(120, 43);
            this.RB_Noise.Name = "RB_Noise";
            this.RB_Noise.Size = new System.Drawing.Size(52, 17);
            this.RB_Noise.TabIndex = 4;
            this.RB_Noise.Text = "Noise";
            this.RB_Noise.UseVisualStyleBackColor = true;
            // 
            // RB_Tint
            // 
            this.RB_Tint.AutoSize = true;
            this.RB_Tint.Location = new System.Drawing.Point(120, 20);
            this.RB_Tint.Name = "RB_Tint";
            this.RB_Tint.Size = new System.Drawing.Size(43, 17);
            this.RB_Tint.TabIndex = 3;
            this.RB_Tint.Text = "Tint";
            this.RB_Tint.UseVisualStyleBackColor = true;
            this.RB_Tint.CheckedChanged += new System.EventHandler(this.RB_Tint_CheckedChanged);
            // 
            // RB_Blk_Wht
            // 
            this.RB_Blk_Wht.AutoSize = true;
            this.RB_Blk_Wht.Location = new System.Drawing.Point(6, 43);
            this.RB_Blk_Wht.Name = "RB_Blk_Wht";
            this.RB_Blk_Wht.Size = new System.Drawing.Size(104, 17);
            this.RB_Blk_Wht.TabIndex = 1;
            this.RB_Blk_Wht.Text = "Black and White";
            this.RB_Blk_Wht.UseVisualStyleBackColor = true;
            // 
            // RB_Contrast
            // 
            this.RB_Contrast.AutoSize = true;
            this.RB_Contrast.Checked = true;
            this.RB_Contrast.Location = new System.Drawing.Point(6, 20);
            this.RB_Contrast.Name = "RB_Contrast";
            this.RB_Contrast.Size = new System.Drawing.Size(64, 17);
            this.RB_Contrast.TabIndex = 0;
            this.RB_Contrast.TabStop = true;
            this.RB_Contrast.Text = "Contrast";
            this.RB_Contrast.UseVisualStyleBackColor = true;
            // 
            // BT_Load
            // 
            this.BT_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Load.Location = new System.Drawing.Point(12, 481);
            this.BT_Load.Name = "BT_Load";
            this.BT_Load.Size = new System.Drawing.Size(95, 23);
            this.BT_Load.TabIndex = 0;
            this.BT_Load.Text = "Load Picture";
            this.BT_Load.UseVisualStyleBackColor = true;
            this.BT_Load.Click += new System.EventHandler(this.BT_Load_Click);
            // 
            // PB_LoadBar
            // 
            this.PB_LoadBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_LoadBar.Location = new System.Drawing.Point(12, 463);
            this.PB_LoadBar.Name = "PB_LoadBar";
            this.PB_LoadBar.Size = new System.Drawing.Size(770, 12);
            this.PB_LoadBar.TabIndex = 2;
            // 
            // TB_Mod
            // 
            this.TB_Mod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Mod.Location = new System.Drawing.Point(324, 481);
            this.TB_Mod.Maximum = 100;
            this.TB_Mod.Name = "TB_Mod";
            this.TB_Mod.Size = new System.Drawing.Size(357, 45);
            this.TB_Mod.TabIndex = 3;
            this.TB_Mod.TickFrequency = 5;
            this.TB_Mod.Value = 50;
            this.TB_Mod.Scroll += new System.EventHandler(this.TB_Mod_Scroll);
            // 
            // BT_Transform
            // 
            this.BT_Transform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Transform.Enabled = false;
            this.BT_Transform.Location = new System.Drawing.Point(687, 481);
            this.BT_Transform.Name = "BT_Transform";
            this.BT_Transform.Size = new System.Drawing.Size(95, 23);
            this.BT_Transform.TabIndex = 4;
            this.BT_Transform.Text = "Transform";
            this.BT_Transform.UseVisualStyleBackColor = true;
            this.BT_Transform.Click += new System.EventHandler(this.BT_Transform_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Less";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "More";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "50";
            // 
            // PicBen_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 582);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_Transform);
            this.Controls.Add(this.TB_Mod);
            this.Controls.Add(this.PB_LoadBar);
            this.Controls.Add(this.BT_Load);
            this.Controls.Add(this.GB_Mod);
            this.Controls.Add(this.PicBox_Main);
            this.MinimumSize = new System.Drawing.Size(810, 620);
            this.Name = "PicBen_Main";
            this.Text = "Picture Bender";
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Main)).EndInit();
            this.GB_Mod.ResumeLayout(false);
            this.GB_Mod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Mod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OFD_LoadPic;
        private System.Windows.Forms.GroupBox GB_Mod;
        private System.Windows.Forms.RadioButton RB_Noise;
        private System.Windows.Forms.RadioButton RB_Tint;
        private System.Windows.Forms.RadioButton RB_Blk_Wht;
        private System.Windows.Forms.RadioButton RB_Contrast;
        private System.Windows.Forms.Button BT_Load;
        private System.Windows.Forms.ProgressBar PB_LoadBar;
        private System.Windows.Forms.TrackBar TB_Mod;
        private System.Windows.Forms.Button BT_Transform;
        private System.Windows.Forms.PictureBox PicBox_Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

