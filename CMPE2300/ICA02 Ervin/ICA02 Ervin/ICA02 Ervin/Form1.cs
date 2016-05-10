/******************************************************************************************************************
*       Author:       Ervin Hernandez
*       Class:        CMPE 2300
*       Programme:    Bouncing Ball
*       File:         Form1.cs
*       Assignment:   A02
*       Date:         2015/09/23
*******************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICA02_Ervin
{
    public partial class Form1 : Form
    {
        CDrawer Canvas;
        List<Ball> BallsList;
        public Form1()
        {
            Canvas = new CDrawer();
            BallsList = new List<Ball>();
            Canvas.ContinuousUpdate = false;
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Canvas.Clear();
            Point p;
            if (Canvas.GetLastMouseLeftClick(out p))
            {
                if ((p.X > 40 && p.Y > 40) && (p.Y < (Canvas.m_ciHeight - 40) && p.X < (Canvas.m_ciWidth - 40))) 
                    BallsList.Add(new Ball(p));
            }
            else if (Canvas.GetLastMouseRightClick(out p))
            {
                BallsList.Clear();
            }
            for (int i = 0; i < BallsList.Count; i++) 
            {
                BallsList[i].MoveBall(Canvas);
                BallsList[i].ShowBall(Canvas);
            }
            if (BallsList.Count > 0)
                Text = BallsList.Last().ToString();
            Canvas.Render();
        }

        private void TB_Xvalue_Scroll(object sender, EventArgs e)
        {
            if (BallsList.Count>0)
                if (CH_All.Checked)
                    for (int i = 0; i < BallsList.Count; i++)
                        BallsList[i].XSpeed = TB_Xvalue.Value;
                else
                    BallsList.Last().XSpeed = TB_Xvalue.Value;
                X_LB.Text = "X: " + TB_Xvalue.Value.ToString();
        }

        private void TB_Yvalue_Scroll(object sender, EventArgs e)
        {
            if (BallsList.Count > 0)
                if (CH_All.Checked)
                    for (int i = 0; i < BallsList.Count; i++)
                        BallsList[i].YSpeed = TB_Yvalue.Value;
                else
                    BallsList.Last().YSpeed = TB_Yvalue.Value;
                Y_TB.Text = "Y: " + TB_Yvalue.Value.ToString();
        }

        private void TB_Opacity_Scroll(object sender, EventArgs e)
        {
            if (BallsList.Count > 0)
                if (CH_All.Checked)
                    for (int i = 0; i < BallsList.Count; i++)
                        BallsList[i].Opacity = TB_Opacity.Value;
                else
                    BallsList.Last().Opacity = TB_Opacity.Value;
            Opacity_LB.Text = "Opacity: " + TB_Opacity.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            X_LB.Text = "X: " + TB_Xvalue.Value.ToString();
            Y_TB.Text = "Y: " + TB_Yvalue.Value.ToString();
            Opacity_LB.Text = " Opacity: " + TB_Opacity.Value.ToString();
        }
    }
}
