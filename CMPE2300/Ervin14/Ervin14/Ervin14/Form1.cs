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
using ErvinDrawer;

namespace Ervin14
{
    public partial class Form1 : Form
    {
        Img canvas;
        List<CShape> shape;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Img(Properties.Resources.doge);
            shape = new List<CShape>();
            CShape.canvas = canvas;
            timer1.Enabled = true;
            timer1.Interval = 50;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            canvas.Clear();
            foreach(CShape c in shape)
            {
                if (c is IMoveable)
                    (c as IMoveable).Move();
                if (c is IAnimate)
                    (c as IAnimate).Animate();
                c.Render();
            }
            canvas.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point p;
            if (canvas.GetLastMousePosition(out p))
                if (p.X > 50 && p.Y > 50 && (p.X < canvas.ScaledWidth - 50) && (p.Y < canvas.ScaledHeight - 50))
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            shape.Clear();
                            break;
                        case Keys.S:
                            shape.Add(new SpinnerBall(p));
                            break;
                        case Keys.M:
                            shape.Add(new MovingBall(p));
                            break;
                        case Keys.O:
                            shape.Add(new PentaBall(p));
                            break;
                    }
                }
        }
    }
}
