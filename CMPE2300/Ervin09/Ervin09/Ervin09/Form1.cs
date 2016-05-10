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

namespace Ervin09
{
    public partial class Form1 : Form
    {
        static Random rng = new Random();
        List<Point> listPoint = new List<Point>();
        LinkedList<Point> linkPoint = new LinkedList<Point>();
        CDrawer canvas = new CDrawer();
        int divisor;
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_makeList_Click(object sender, EventArgs e)
        {
            divisor = (int)numericUpDown.Value;
            int i = 0;
            //int num = rng.Next(0, (canvas.ScaledWidth / divisor) * divisor);
            listPoint.Clear();
            listPoint.Add(new Point((rng.Next(0, (canvas.ScaledWidth / divisor)) * divisor), (rng.Next(0, (canvas.ScaledHeight / divisor)) * divisor)));
            while (listPoint.Count != ((canvas.ScaledWidth/divisor ) * (canvas.ScaledHeight/divisor))) 
            {
                Point temp = new Point((rng.Next(0, (canvas.ScaledWidth / divisor)) * divisor), (rng.Next(0, (canvas.ScaledHeight / divisor)) * divisor));
                if (!listPoint.Contains(temp))
                {
                    listPoint.Add(temp);
                    i++;
                }
            }
            bt_makeList.Text = "Made " + listPoint.Count + " Points";
            canvas.Clear();
            for (int x = 0; x < listPoint.Count; ++x) 
            {
                if ((x + 1) < listPoint.Count) 
                if (listPoint[x].X == listPoint[x + 1].X || listPoint[x].Y == listPoint[x + 1].Y)
                    canvas.AddLine(listPoint[x].X, listPoint[x].Y, listPoint[x + 1].X, listPoint[x + 1].Y, Color.Fuchsia);
                else
                    canvas.AddLine(listPoint[x].X, listPoint[x].Y, listPoint[x + 1].X, listPoint[x + 1].Y, Color.Fuchsia);
            }
            canvas.Render();
        }

        private void bt_populate_Click(object sender, EventArgs e)
        {
            linkPoint.Clear();
            foreach(Point p in listPoint)
            {
                // first node if empty
                if (linkPoint.Count == 0)
                    linkPoint.AddFirst(p);
                else
                {
                    LinkedListNode<Point> listTemp = linkPoint.First;
                    while ((p.Y * canvas.ScaledWidth + p.X).CompareTo(listTemp.Value.Y * canvas.ScaledWidth + listTemp.Value.X) > 0 && listTemp.Next != null) 
                    {
                        listTemp = listTemp.Next;
                    }
                    if (listTemp.Next == null && (p.Y * canvas.ScaledWidth + p.X).CompareTo(listTemp.Value.Y * canvas.ScaledWidth + listTemp.Value.X) > 0)
                        linkPoint.AddLast(p);
                    else
                        linkPoint.AddBefore(listTemp, p);
                }
               
            }
            canvas.Clear();
            for (LinkedListNode<Point> i = linkPoint.First; i.Next != null; i = i.Next)
                canvas.AddLine(i.Value.X, i.Value.Y, i.Next.Value.X, i.Next.Value.Y, Color.Yellow);
            bt_populate.Text = "Made " + linkPoint.Count + " Points";
        }
    }
}
