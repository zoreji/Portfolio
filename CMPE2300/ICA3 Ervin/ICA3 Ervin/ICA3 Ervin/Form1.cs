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

namespace ICA3_Ervin
{
    public partial class Form1 : Form
    {
        List<Ball> ball_list;
        Thread RunBalls;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball_list = new List<Ball>();
            try
            {
                RunBalls = new Thread(ShowThemBalls);
                RunBalls.IsBackground = true;
                RunBalls.Start();
            }
            catch { }
        }

        private void TB_BallSize_Scroll(object sender, EventArgs e)
        {
            Text = "Size: " + TB_BallSize.Value.ToString();
            Ball.Set_Radius = TB_BallSize.Value;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    ball_list.Clear();
                    break;
                case Keys.Add:
                    for (int i = 0; i < 5; i++)
                        ball_list.Add(new Ball());
                    break;
            }
        }
        private void ShowThemBalls()
        {
            while(true)
            {
                Ball.Loading = true;
                for (int i = 0; i < ball_list.Count; i++)
                {
                    ball_list[i].ShowBall();
                    ball_list[i].MoveBall();
                }
                Ball.Loading = false;
                Thread.Sleep(25);
            }
        }
    }
}
