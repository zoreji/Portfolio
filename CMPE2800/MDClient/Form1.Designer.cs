namespace MDClient
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
            this._StatStrip = new System.Windows.Forms.StatusStrip();
            this._LBConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this._LBColor = new System.Windows.Forms.ToolStripStatusLabel();
            this._LBThickness = new System.Windows.Forms.ToolStripStatusLabel();
            this._LBAlpha = new System.Windows.Forms.ToolStripStatusLabel();
            this._LBFrames = new System.Windows.Forms.ToolStripStatusLabel();
            this._LBFragments = new System.Windows.Forms.ToolStripStatusLabel();
            this._LBDestack = new System.Windows.Forms.ToolStripStatusLabel();
            this._LBBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this._StatStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _StatStrip
            // 
            this._StatStrip.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._StatStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._LBConnect,
            this._LBColor,
            this._LBThickness,
            this._LBAlpha,
            this._LBFrames,
            this._LBFragments,
            this._LBDestack,
            this._LBBytes});
            this._StatStrip.Location = new System.Drawing.Point(0, 586);
            this._StatStrip.Name = "_StatStrip";
            this._StatStrip.Size = new System.Drawing.Size(819, 24);
            this._StatStrip.TabIndex = 0;
            this._StatStrip.Text = "statusStrip1";
            // 
            // _LBConnect
            // 
            this._LBConnect.BackColor = System.Drawing.Color.White;
            this._LBConnect.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._LBConnect.Name = "_LBConnect";
            this._LBConnect.Size = new System.Drawing.Size(69, 19);
            this._LBConnect.Text = "Connect...";
            this._LBConnect.Click += new System.EventHandler(this._LBConnect_Click);
            // 
            // _LBColor
            // 
            this._LBColor.BackColor = System.Drawing.Color.White;
            this._LBColor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._LBColor.Name = "_LBColor";
            this._LBColor.Size = new System.Drawing.Size(42, 19);
            this._LBColor.Text = "Color";
            this._LBColor.Click += new System.EventHandler(this._LBColor_Click);
            // 
            // _LBThickness
            // 
            this._LBThickness.BackColor = System.Drawing.Color.White;
            this._LBThickness.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._LBThickness.Name = "_LBThickness";
            this._LBThickness.Size = new System.Drawing.Size(67, 19);
            this._LBThickness.Text = "Thickness";
            // 
            // _LBAlpha
            // 
            this._LBAlpha.BackColor = System.Drawing.Color.White;
            this._LBAlpha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._LBAlpha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._LBAlpha.Name = "_LBAlpha";
            this._LBAlpha.Size = new System.Drawing.Size(38, 19);
            this._LBAlpha.Text = "Alpha";
            // 
            // _LBFrames
            // 
            this._LBFrames.BackColor = System.Drawing.Color.White;
            this._LBFrames.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._LBFrames.Name = "_LBFrames";
            this._LBFrames.Size = new System.Drawing.Size(91, 19);
            this._LBFrames.Text = "Frames RX\'ed";
            // 
            // _LBFragments
            // 
            this._LBFragments.BackColor = System.Drawing.Color.White;
            this._LBFragments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._LBFragments.Name = "_LBFragments";
            this._LBFragments.Size = new System.Drawing.Size(74, 19);
            this._LBFragments.Text = "Fragments";
            // 
            // _LBDestack
            // 
            this._LBDestack.BackColor = System.Drawing.Color.White;
            this._LBDestack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._LBDestack.Name = "_LBDestack";
            this._LBDestack.Size = new System.Drawing.Size(85, 19);
            this._LBDestack.Text = "Destack Avg";
            // 
            // _LBBytes
            // 
            this._LBBytes.BackColor = System.Drawing.Color.White;
            this._LBBytes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._LBBytes.Name = "_LBBytes";
            this._LBBytes.Size = new System.Drawing.Size(80, 19);
            this._LBBytes.Text = "Bytes RX\'ed";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 610);
            this.Controls.Add(this._StatStrip);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this._StatStrip.ResumeLayout(false);
            this._StatStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel _LBColor;
        private System.Windows.Forms.ToolStripStatusLabel _LBThickness;
        private System.Windows.Forms.ToolStripStatusLabel _LBFrames;
        private System.Windows.Forms.ToolStripStatusLabel _LBFragments;
        private System.Windows.Forms.ToolStripStatusLabel _LBDestack;
        private System.Windows.Forms.ToolStripStatusLabel _LBBytes;
        private System.Windows.Forms.StatusStrip _StatStrip;
        private System.Windows.Forms.ToolStripStatusLabel _LBConnect;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripStatusLabel _LBAlpha;
        private System.Windows.Forms.Timer Timer;
    }
}

