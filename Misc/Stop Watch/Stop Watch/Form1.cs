using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stop_Watch
{
    public partial class Stop_Watch_Form : Form
    {
        int time = 0;
        int msec = 0;
        int sec = 0;
        int min = 0;
        public Stop_Watch_Form()
        {
            InitializeComponent();
        }

        private void Stop_Watch_Form_Load(object sender, EventArgs e)
        {
            timer();
            timer1.Enabled = false;
            StopBT.Enabled = false;
            ResetBT.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            msec = time % 10;
            sec = (time / 10) % 60;
            min = (time / 600) % 60;
            mSecTB.Text = msec.ToString();
            SecTB.Text = sec.ToString();
            MinTB.Text = min.ToString();
        }

        private void StartBT_Click(object sender, EventArgs e)
        {
            timer();
            timer1.Enabled = true;
            StartBT.Enabled = false;
            StopBT.Enabled = true;
            ResetBT.Enabled = true;
        }

        private void StopBT_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            StartBT.Enabled = true;
            StopBT.Enabled = false;
            ResetBT.Enabled = true;
        }

        private void ResetBT_Click(object sender, EventArgs e)
        {
            timer();
            timer1.Enabled = false;
            StartBT.Enabled = true;
            StopBT.Enabled = false;
            ResetBT.Enabled = false;
        }
        private void timer()
        {
            time = 0;
            msec = 0;
            sec = 0;
            min = 0;
            mSecTB.Text = msec.ToString();
            SecTB.Text = sec.ToString();
            MinTB.Text = min.ToString();
        }
    }
}
