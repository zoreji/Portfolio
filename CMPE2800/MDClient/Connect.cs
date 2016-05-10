using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDClient
{
    public delegate void DelVoidVoid(object sender);
    public partial class Connect : Form
    {
        public DelVoidVoid sendText;
        public Connect()
        {
            InitializeComponent();
        }

        private void _BSendData_Click(object sender, EventArgs e)
        {
            List<string> ConnectInfo = new List<string>();
            if(sendText != null)
            {
                ConnectInfo.Add(_TBAddress.Text);
                ConnectInfo.Add(_TBPort.Text);
                sendText(ConnectInfo);
            }
            this.Hide();
        }
    }
}
