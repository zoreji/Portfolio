namespace nAudioPlaybackStarter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.meter1 = new Meter_Control.Meter();
            this.ud_alarm = new System.Windows.Forms.NumericUpDown();
            this.bt_alarm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ud_alarm)).BeginInit();
            this.SuspendLayout();
            // 
            // meter1
            // 
            this.meter1.alert_Lvl = 0.89D;
            this.meter1.dB = 0F;
            this.meter1.LeftavgLvl = 0F;
            this.meter1.lf_degrees = 1F;
            this.meter1.Location = new System.Drawing.Point(0, -2);
            this.meter1.maxLvl = 1F;
            this.meter1.minLvl = 0F;
            this.meter1.Name = "meter1";
            this.meter1.rg_degrees = 1F;
            this.meter1.RightavgLvl = 0F;
            this.meter1.Size = new System.Drawing.Size(642, 398);
            this.meter1.Speed = Meter_Control.Meter.Meter_type.Medium;
            this.meter1.TabIndex = 0;
            this.meter1.Value = ((System.Drawing.PointF)(resources.GetObject("meter1.Value")));
            // 
            // ud_alarm
            // 
            this.ud_alarm.DecimalPlaces = 2;
            this.ud_alarm.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ud_alarm.Location = new System.Drawing.Point(596, 352);
            this.ud_alarm.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_alarm.Name = "ud_alarm";
            this.ud_alarm.Size = new System.Drawing.Size(46, 20);
            this.ud_alarm.TabIndex = 1;
            // 
            // bt_alarm
            // 
            this.bt_alarm.Location = new System.Drawing.Point(490, 349);
            this.bt_alarm.Name = "bt_alarm";
            this.bt_alarm.Size = new System.Drawing.Size(100, 23);
            this.bt_alarm.TabIndex = 2;
            this.bt_alarm.Text = "Set Alarm Level";
            this.bt_alarm.UseVisualStyleBackColor = true;
            this.bt_alarm.Click += new System.EventHandler(this.bt_alarm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 384);
            this.Controls.Add(this.bt_alarm);
            this.Controls.Add(this.ud_alarm);
            this.Controls.Add(this.meter1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ud_alarm)).EndInit();
            this.ResumeLayout(false);

    }








        #endregion

        private Meter_Control.Meter meter1;
        private System.Windows.Forms.NumericUpDown ud_alarm;
        private System.Windows.Forms.Button bt_alarm;
    }
}

