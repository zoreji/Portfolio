using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ervin11
{
    public partial class Form1 : Form
    {
        Drawer up = new Drawer(150);
        GDI go = new GDI();
        Img i = new Img();
        public Form1()
        {
            InitializeComponent();
        }
    }
}
