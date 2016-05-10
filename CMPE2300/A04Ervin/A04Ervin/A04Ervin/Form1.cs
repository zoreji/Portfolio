using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A04Ervin
{
    public partial class Form1 : Form
    {
        List<Ball> balls;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            balls = new List<Ball>();
            label1.Text = "Size: " + TB_Size.Value.ToString();
        }

        private void BT_Add_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            int count = 0;
            Ball temp;
            Ball.Loading = true;
            bool check = false;
            while (count < 25 && progressBar.Value <1000)
            {
                temp = new Ball(TB_Size.Value);
                check = true;
                foreach(Ball b in balls)
                    if (check && temp.Equals(b))
                    {
                        progressBar.Value++;
                        check = false;
                    }
                if (check)
                {
                    balls.Add(temp);
                    count++;
                }
            }
            foreach (Ball b in balls)
            {
                b.Addball();
            }
            Ball.Loading = false;
            Text = "Balls: " + balls.Count.ToString() + "Discarded: " + progressBar.Value.ToString();
        }

        private void TB_Size_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Size: " + TB_Size.Value.ToString();
        }
    }
}
