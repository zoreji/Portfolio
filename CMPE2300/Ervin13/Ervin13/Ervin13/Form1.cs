using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErvinDrawer;
using GDIDrawer;

namespace Ervin13
{
    public partial class Form1 : Form
    {
        static Random rng = new Random();
        Img canvas;
        List<Light> shine;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Img(Properties.Resources.doge);
            shine = new List<Light>();
            canvas.ContinuousUpdate = false;
            timer.Enabled = true;
            timer.Interval = 100;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Point p;
            if (canvas.GetLastMouseLeftClick(out p))
            {
                int pick = rng.Next(3);
                switch (pick)
                {
                    case 0:
                        shine.Add(new FadeLight(p));
                        break;
                    case 1:
                        shine.Add(new ShrinkLight(p));
                        break;
                    case 2:
                        shine.Add(new SpinLight(p));
                        break;
                }
                
            }
            canvas.Clear();
            foreach(Light l in shine)
            {
                l.Animate();
                l.Draw(canvas);
            }
            shine.RemoveAll(obj => obj.SetKillMe);
            canvas.Render();
        }
    }
}
