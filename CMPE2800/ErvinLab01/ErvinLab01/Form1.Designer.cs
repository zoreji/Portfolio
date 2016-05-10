namespace ErvinLab01
{
    partial class _fmFileStats
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
            this._gbFiles = new System.Windows.Forms.GroupBox();
            this._btOpen = new System.Windows.Forms.Button();
            this._tbSize = new System.Windows.Forms.TextBox();
            this._tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._gb1s = new System.Windows.Forms.GroupBox();
            this._tbResult = new System.Windows.Forms.TextBox();
            this._pbUpdate = new System.Windows.Forms.ProgressBar();
            this._gbByteCount = new System.Windows.Forms.GroupBox();
            this._lvCount = new System.Windows.Forms.ListView();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this._gbFiles.SuspendLayout();
            this._gb1s.SuspendLayout();
            this._gbByteCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gbFiles
            // 
            this._gbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gbFiles.Controls.Add(this._btOpen);
            this._gbFiles.Controls.Add(this._tbSize);
            this._gbFiles.Controls.Add(this._tbName);
            this._gbFiles.Controls.Add(this.label2);
            this._gbFiles.Controls.Add(this.label1);
            this._gbFiles.Location = new System.Drawing.Point(12, 12);
            this._gbFiles.Name = "_gbFiles";
            this._gbFiles.Size = new System.Drawing.Size(360, 99);
            this._gbFiles.TabIndex = 0;
            this._gbFiles.TabStop = false;
            this._gbFiles.Text = "File Details";
            // 
            // _btOpen
            // 
            this._btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btOpen.Location = new System.Drawing.Point(279, 68);
            this._btOpen.Name = "_btOpen";
            this._btOpen.Size = new System.Drawing.Size(75, 23);
            this._btOpen.TabIndex = 4;
            this._btOpen.Text = "Select File...";
            this._btOpen.UseVisualStyleBackColor = true;
            this._btOpen.Click += new System.EventHandler(this._btOpen_Click);
            // 
            // _tbSize
            // 
            this._tbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tbSize.Location = new System.Drawing.Point(69, 42);
            this._tbSize.Name = "_tbSize";
            this._tbSize.ReadOnly = true;
            this._tbSize.Size = new System.Drawing.Size(285, 20);
            this._tbSize.TabIndex = 3;
            // 
            // _tbName
            // 
            this._tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tbName.Location = new System.Drawing.Point(69, 19);
            this._tbName.Name = "_tbName";
            this._tbName.ReadOnly = true;
            this._tbName.Size = new System.Drawing.Size(285, 20);
            this._tbName.TabIndex = 2;
            this._tbName.Text = "Select a File...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // _gb1s
            // 
            this._gb1s.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gb1s.Controls.Add(this._tbResult);
            this._gb1s.Controls.Add(this._pbUpdate);
            this._gb1s.Location = new System.Drawing.Point(12, 117);
            this._gb1s.Name = "_gb1s";
            this._gb1s.Size = new System.Drawing.Size(360, 64);
            this._gb1s.TabIndex = 1;
            this._gb1s.TabStop = false;
            this._gb1s.Text = "1s Percentage";
            // 
            // _tbResult
            // 
            this._tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._tbResult.Location = new System.Drawing.Point(6, 38);
            this._tbResult.Name = "_tbResult";
            this._tbResult.ReadOnly = true;
            this._tbResult.Size = new System.Drawing.Size(348, 20);
            this._tbResult.TabIndex = 2;
            // 
            // _pbUpdate
            // 
            this._pbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._pbUpdate.Location = new System.Drawing.Point(6, 19);
            this._pbUpdate.Name = "_pbUpdate";
            this._pbUpdate.Size = new System.Drawing.Size(348, 15);
            this._pbUpdate.TabIndex = 1;
            // 
            // _gbByteCount
            // 
            this._gbByteCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gbByteCount.Controls.Add(this._lvCount);
            this._gbByteCount.Location = new System.Drawing.Point(12, 187);
            this._gbByteCount.Name = "_gbByteCount";
            this._gbByteCount.Size = new System.Drawing.Size(360, 163);
            this._gbByteCount.TabIndex = 1;
            this._gbByteCount.TabStop = false;
            this._gbByteCount.Text = "Byte Counts";
            // 
            // _lvCount
            // 
            this._lvCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lvCount.Location = new System.Drawing.Point(6, 19);
            this._lvCount.Name = "_lvCount";
            this._lvCount.Size = new System.Drawing.Size(348, 138);
            this._lvCount.TabIndex = 0;
            this._lvCount.UseCompatibleStateImageBehavior = false;
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // _fmFileStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this._gbByteCount);
            this.Controls.Add(this._gb1s);
            this.Controls.Add(this._gbFiles);
            this.Name = "_fmFileStats";
            this.Text = "File Stats";
            this._gbFiles.ResumeLayout(false);
            this._gbFiles.PerformLayout();
            this._gb1s.ResumeLayout(false);
            this._gb1s.PerformLayout();
            this._gbByteCount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbFiles;
        private System.Windows.Forms.Button _btOpen;
        private System.Windows.Forms.TextBox _tbSize;
        private System.Windows.Forms.TextBox _tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox _gb1s;
        private System.Windows.Forms.TextBox _tbResult;
        private System.Windows.Forms.ProgressBar _pbUpdate;
        private System.Windows.Forms.GroupBox _gbByteCount;
        private System.Windows.Forms.ListView _lvCount;
        private System.Windows.Forms.OpenFileDialog OFD;
    }
}

