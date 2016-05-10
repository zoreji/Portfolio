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

namespace Ervin07
{
    public partial class Form1 : Form
    {
        List<Block> block;
        public Form1()
        {
            InitializeComponent();
            block = new List<Block>();
            
        }
        private void ShowBlocks()
        {
            Block._Canvas.Clear();
            Point P = new Point();
            P.Y = 0;
            P.X = 0;
            foreach(Block b in block)
            {
                if ((P.X + b._Width) < Block._Canvas.ScaledWidth)
                {
                    b.ShowBlock(P);
                    P.X += b._Width;
                }
                else
                {
                    P.X = 0;
                    P.Y += Block._Height;
                }
            }
            Block._Canvas.Render();
        }
        private void bt_populate_Click(object sender, EventArgs e)
        {
            block.Clear();
            int sum = 0;
            int i = 0;
            block.Add(new Block());
            while (sum < (((Block._Canvas.ScaledHeight * Block._Canvas.ScaledWidth) / Block._Height) * 0.8))
            {
                Block temp = new Block();
                if (block.Contains(temp))
                    block[i] = temp;
                else
                {
                    i++;
                    block.Add(new Block());
                }
                sum = 0;
                foreach (Block b in block)
                    sum += b._Width;
            }
            ShowBlocks();
            MaxMin();
        }

        private void bt_color_Click(object sender, EventArgs e)
        {
            block.Sort();
            ShowBlocks();
        }

        private void bt_width_Click(object sender, EventArgs e)
        {
            block.Sort(Block.CompareWidth);
            ShowBlocks();
        }

        private void bt_widthDesc_Click(object sender, EventArgs e)
        {
            block.Sort(Block.CompareDescWidth);
            ShowBlocks();
        }

        private void bt_widthColor_Click(object sender, EventArgs e)
        {
            block.Sort(Block.CompareWidthColor);
            ShowBlocks();
        }

        private void bt_bright_Click(object sender, EventArgs e)
        {
            int count = block.Count;
            block.RemoveAll(Block.RemoveBright);
            Text = "Remove Count: " + (count - block.Count);
            MaxMin();
            ShowBlocks();
        }

        private void bt_longer100_Click(object sender, EventArgs e)
        {
            int count = block.Count();
            block.RemoveAll(obj => { if (obj == null) return false; return obj._Width > tb_bar.Value; });
            Text = "Remove Count: " + (count - block.Count);
            MaxMin();
            ShowBlocks();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            block.ForEach(obj => obj._HighLight = false);
            block.FindAll(obj => (Math.Abs(e.X - obj._Width) <= 10)).ForEach(obj => obj._HighLight = true);
            ShowBlocks();
        }
        private void MaxMin()
        {
            if (block.Count > 1)
            {
                tb_bar.Minimum = block.Min(obj => obj._Width);
                tb_bar.Maximum = block.Max(obj => obj._Width);
                tb_bar.Value = (tb_bar.Maximum - tb_bar.Minimum) / 2;
                bt_longer100.Text = "Remove Longer than " + tb_bar.Value;
            }
        }

        private void tb_bar_Scroll(object sender, EventArgs e)
        {
            bt_longer100.Text = "Remove Longer than " + tb_bar.Value;
        }
    }
}
