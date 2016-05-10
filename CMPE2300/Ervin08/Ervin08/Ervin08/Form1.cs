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

namespace Ervin08
{
    public partial class Form1 : Form
    {
        Stack<Sheeple> Gather = new Stack<Sheeple>();
        List<Queue<Sheeple>> LineThemUp = new List<Queue<Sheeple>>();
        CDrawer airport;
        int Pass;
        int TickCount;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_simulate_Click(object sender, EventArgs e)
        {
            if(airport != null)
                airport.Close();
            Gather.Clear();
            LineThemUp.Clear();
            while (Gather.Count < 200)
                Gather.Push(new Sheeple());
            for (int i = 0; i < numericUpDown.Value; ++i)
                LineThemUp.Add(new Queue<Sheeple>());
            Pass = 0;
            TickCount = 0;
            airport = new CDrawer(800, LineThemUp.Count * 20);
            airport.Scale = 20;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (airport == null)
                return;
            if (Gather.Count != 0)
                foreach (Queue<Sheeple> q in LineThemUp)
                    if (q.Count < 10 && Gather.Count != 0)
                        q.Enqueue(Gather.Pop());

            listBox.Items.Clear();
            foreach (Sheeple s in Gather)
            {
                Pass += s._ItemsTotal;
                listBox.Items.Add(s._ItemsTotal);
            }

            foreach (Queue<Sheeple> q in LineThemUp)
            {
                if (q.Count != 0)
                {
                    Sheeple temp = q.Peek();
                    temp.CavitySearch();
                    if (temp.Done)
                    {
                        Pass += temp._ItemsTotal;
                        q.Dequeue();
                    }
                }
            }
            airport.Clear();
            int x = 0;
            int y = 0;
            foreach (Queue<Sheeple> q in LineThemUp)
            {
                x = 0;
                foreach (Sheeple s in q)
                {
                    airport.AddRectangle(x, y, s._ItemsCurrent, 1, Color.FromArgb(s._Race));
                    x += s._ItemsCurrent;
                }
                y++;
            }
            airport.Render();
        }
    }
}
