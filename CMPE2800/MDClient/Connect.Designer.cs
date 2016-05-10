namespace MDClient
{
    partial class Connect
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._TBAddress = new System.Windows.Forms.TextBox();
            this._TBPort = new System.Windows.Forms.TextBox();
            this._BSendData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port: ";
            // 
            // _TBAddress
            // 
            this._TBAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TBAddress.Location = new System.Drawing.Point(102, 6);
            this._TBAddress.Name = "_TBAddress";
            this._TBAddress.Size = new System.Drawing.Size(170, 23);
            this._TBAddress.TabIndex = 2;
            this._TBAddress.Text = "bits.net.nait.ca";
            // 
            // _TBPort
            // 
            this._TBPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TBPort.Location = new System.Drawing.Point(60, 39);
            this._TBPort.Name = "_TBPort";
            this._TBPort.Size = new System.Drawing.Size(94, 23);
            this._TBPort.TabIndex = 3;
            this._TBPort.Text = "1666";
            // 
            // _BSendData
            // 
            this._BSendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BSendData.Location = new System.Drawing.Point(160, 39);
            this._BSendData.Name = "_BSendData";
            this._BSendData.Size = new System.Drawing.Size(112, 23);
            this._BSendData.TabIndex = 4;
            this._BSendData.Text = "Connect";
            this._BSendData.UseVisualStyleBackColor = true;
            this._BSendData.Click += new System.EventHandler(this._BSendData_Click);
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 73);
            this.Controls.Add(this._BSendData);
            this.Controls.Add(this._TBPort);
            this.Controls.Add(this._TBAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Connect";
            this.Text = "Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _TBAddress;
        private System.Windows.Forms.TextBox _TBPort;
        private System.Windows.Forms.Button _BSendData;
    }
}