namespace Client
{
    partial class _fmClient
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
            this._btnConnect = new System.Windows.Forms.Button();
            this._tbHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbPort = new System.Windows.Forms.TextBox();
            this._tbGuess = new System.Windows.Forms.TextBox();
            this._trbGuess = new System.Windows.Forms.TrackBar();
            this._lbLow = new System.Windows.Forms.Label();
            this._lbHigh = new System.Windows.Forms.Label();
            this._gbConnection = new System.Windows.Forms.GroupBox();
            this._lbResult = new System.Windows.Forms.ListBox();
            this._btGuess = new System.Windows.Forms.Button();
            this._gbHiLo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._trbGuess)).BeginInit();
            this._gbConnection.SuspendLayout();
            this._gbHiLo.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnConnect
            // 
            this._btnConnect.Location = new System.Drawing.Point(6, 19);
            this._btnConnect.Name = "_btnConnect";
            this._btnConnect.Size = new System.Drawing.Size(75, 23);
            this._btnConnect.TabIndex = 0;
            this._btnConnect.Text = "Connect";
            this._btnConnect.UseVisualStyleBackColor = true;
            this._btnConnect.Click += new System.EventHandler(this._btnConnect_Click);
            // 
            // _tbHost
            // 
            this._tbHost.Location = new System.Drawing.Point(87, 22);
            this._tbHost.Name = "_tbHost";
            this._tbHost.Size = new System.Drawing.Size(210, 20);
            this._tbHost.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port :";
            // 
            // _tbPort
            // 
            this._tbPort.Location = new System.Drawing.Point(341, 22);
            this._tbPort.Name = "_tbPort";
            this._tbPort.Size = new System.Drawing.Size(83, 20);
            this._tbPort.TabIndex = 3;
            // 
            // _tbGuess
            // 
            this._tbGuess.Location = new System.Drawing.Point(90, 19);
            this._tbGuess.Name = "_tbGuess";
            this._tbGuess.Size = new System.Drawing.Size(248, 20);
            this._tbGuess.TabIndex = 4;
            // 
            // _trbGuess
            // 
            this._trbGuess.Location = new System.Drawing.Point(47, 74);
            this._trbGuess.Name = "_trbGuess";
            this._trbGuess.Size = new System.Drawing.Size(330, 45);
            this._trbGuess.TabIndex = 5;
            // 
            // _lbLow
            // 
            this._lbLow.AutoSize = true;
            this._lbLow.Location = new System.Drawing.Point(6, 88);
            this._lbLow.Name = "_lbLow";
            this._lbLow.Size = new System.Drawing.Size(35, 13);
            this._lbLow.TabIndex = 6;
            this._lbLow.Text = "label2";
            // 
            // _lbHigh
            // 
            this._lbHigh.AutoSize = true;
            this._lbHigh.Location = new System.Drawing.Point(383, 88);
            this._lbHigh.Name = "_lbHigh";
            this._lbHigh.Size = new System.Drawing.Size(35, 13);
            this._lbHigh.TabIndex = 7;
            this._lbHigh.Text = "label3";
            // 
            // _gbConnection
            // 
            this._gbConnection.Controls.Add(this._tbHost);
            this._gbConnection.Controls.Add(this.label1);
            this._gbConnection.Controls.Add(this._btnConnect);
            this._gbConnection.Controls.Add(this._tbPort);
            this._gbConnection.Location = new System.Drawing.Point(12, 12);
            this._gbConnection.Name = "_gbConnection";
            this._gbConnection.Size = new System.Drawing.Size(430, 63);
            this._gbConnection.TabIndex = 8;
            this._gbConnection.TabStop = false;
            this._gbConnection.Text = "Connection";
            // 
            // _lbResult
            // 
            this._lbResult.FormattingEnabled = true;
            this._lbResult.Location = new System.Drawing.Point(6, 129);
            this._lbResult.Name = "_lbResult";
            this._lbResult.Size = new System.Drawing.Size(418, 95);
            this._lbResult.TabIndex = 9;
            // 
            // _btGuess
            // 
            this._btGuess.Location = new System.Drawing.Point(176, 45);
            this._btGuess.Name = "_btGuess";
            this._btGuess.Size = new System.Drawing.Size(75, 23);
            this._btGuess.TabIndex = 10;
            this._btGuess.Text = "Guess";
            this._btGuess.UseVisualStyleBackColor = true;
            this._btGuess.Click += new System.EventHandler(this._btGuess_Click);
            // 
            // _gbHiLo
            // 
            this._gbHiLo.Controls.Add(this._tbGuess);
            this._gbHiLo.Controls.Add(this._lbResult);
            this._gbHiLo.Controls.Add(this._lbHigh);
            this._gbHiLo.Controls.Add(this._btGuess);
            this._gbHiLo.Controls.Add(this._lbLow);
            this._gbHiLo.Controls.Add(this._trbGuess);
            this._gbHiLo.Location = new System.Drawing.Point(12, 81);
            this._gbHiLo.Name = "_gbHiLo";
            this._gbHiLo.Size = new System.Drawing.Size(430, 230);
            this._gbHiLo.TabIndex = 11;
            this._gbHiLo.TabStop = false;
            this._gbHiLo.Text = "HiLo";
            // 
            // _fmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 323);
            this.Controls.Add(this._gbHiLo);
            this.Controls.Add(this._gbConnection);
            this.MaximumSize = new System.Drawing.Size(470, 361);
            this.MinimumSize = new System.Drawing.Size(470, 361);
            this.Name = "_fmClient";
            this.Text = "Client";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this._fmClient_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._trbGuess)).EndInit();
            this._gbConnection.ResumeLayout(false);
            this._gbConnection.PerformLayout();
            this._gbHiLo.ResumeLayout(false);
            this._gbHiLo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnConnect;
        private System.Windows.Forms.TextBox _tbHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbPort;
        private System.Windows.Forms.TextBox _tbGuess;
        private System.Windows.Forms.TrackBar _trbGuess;
        private System.Windows.Forms.Label _lbLow;
        private System.Windows.Forms.Label _lbHigh;
        private System.Windows.Forms.GroupBox _gbConnection;
        private System.Windows.Forms.ListBox _lbResult;
        private System.Windows.Forms.Button _btGuess;
        private System.Windows.Forms.GroupBox _gbHiLo;
    }
}

