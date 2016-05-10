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

namespace A06Ervin
{
    public partial class Form1 : Form
    {
        List<Ball> collided;
        List<Ball> blueball;
        List<Ball> greenball;
        CDrawer canvas;
        CDrawer canvas2;
        public Form1()
        {
            InitializeComponent();
            greenball = new List<Ball>();
            blueball = new List<Ball>();
            canvas = new CDrawer(600,300);
            canvas2 = new CDrawer(600, 300);
            collided = new List<Ball>();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Point p;
            if (canvas.GetLastMouseLeftClick(out p))
            {
                if ((p.X > 50 && p.Y > 50) && (p.Y < (canvas.m_ciHeight - 50) && p.X < (canvas.m_ciWidth - 50)))
                {
                    Ball tempball = new Ball(p, Color.Green);
                    if (!greenball.Contains(tempball))
                    {
                        greenball.Add(tempball);
                    }
                }
            }
            if (canvas.GetLastMouseRightClick(out p))
            {
                if ((p.X > 50 && p.Y > 50) && (p.Y < (canvas.m_ciHeight - 50) && p.X < (canvas.m_ciWidth - 50)))
                {
                    Ball tempball = new Ball(p, Color.Blue);
                    if (blueball.IndexOf(tempball) == -1)
                    {
                        blueball.Insert(0,tempball);
                    }
                }
            }
            foreach(Ball b in greenball)
            {
                b.MoveBall(canvas);
            }
            foreach (Ball b in blueball)
            { 
                b.MoveBall(canvas);
            }
            foreach(Ball b in collided)
            {
                b.MoveBall(canvas2);
            }
            List<Ball> temp = blueball.Intersect(greenball).ToList();
            foreach(Ball b in temp)
            {
                while (greenball.Remove(b))
                    while (blueball.Remove(b)) ;
                    b._ballcolor = Color.Red;
            }
            collided = new List<Ball>(collided.Concat(temp));
            canvas.Clear();
            canvas2.Clear();
            for (int i = 0; i < greenball.Count; ++i)
                greenball[i].ShowBall(canvas, i);
            for (int i = 0; i < blueball.Count; ++i)
                blueball[i].ShowBall(canvas, i);
            for (int i = 0; i < collided.Count; ++i) 
                collided[i].ShowBall(canvas2, i);
            canvas.AddText("Green : " + greenball.Count() + " Blue : " + blueball.Count(), 24, Color.FromArgb(125, Color.Gray));
            canvas2.AddText("Red : " + collided.Count, 24, Color.FromArgb(125, Color.Gray));
            canvas2.Render();
            canvas.Render();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas.ContinuousUpdate = false;
            canvas2.ContinuousUpdate = false;

        }
    }
}
