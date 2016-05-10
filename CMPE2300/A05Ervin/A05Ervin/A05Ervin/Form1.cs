using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace A05Ervin
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
            render();
            Text = "Balls: " + balls.Count.ToString() + "Discarded: " + progressBar.Value.ToString();
        }

        private void TB_Size_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Size: " + TB_Size.Value.ToString();
        }

        private void RB_Radius_Click(object sender, EventArgs e)
        {
            Ball.Loading = true;
            if (RB_Color.Checked)
            {
                Ball._eSortType = Ball.ESortType.eColor;
            }
            if (RB_Distance.Checked)
            {
                Ball._eSortType = Ball.ESortType.eDistance;
            }
            if (RB_Radius.Checked)
            {
                Ball._eSortType = Ball.ESortType.eRadius;
            }
            balls.Sort();
            render();
        }
        private void render()
        {
            foreach (Ball b in balls)
            {
                Thread.Sleep(10);
                b.Addball();
                Ball.Loading = false;
            }
        }

        private void BT_ClearBall_Click(object sender, EventArgs e)
        {
            Ball.Loading = true;
            balls.Clear();
            progressBar.Value = 0;
            Ball.Loading = false;
        }
    }
}
