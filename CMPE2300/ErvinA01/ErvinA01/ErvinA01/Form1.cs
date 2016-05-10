using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;
using GDIDrawer;

namespace ErvinA01
{
    public partial class Form1 : Form
    {
        Random rng = new Random();
        CDrawer TrekWindow = new CDrawer();
        List<TrekLight> listTrek;
        public Form1()
        {
            InitializeComponent();
        }
        public class TrekLight
        {
            Color _LightColor;
            byte _byThreshold;
            byte _byTick;
            int _Border;
            public TrekLight() : this(RandColor.GetColor(), 64, 5)
            {

            }
            public TrekLight(Color LightColor, byte Threshold, int Border = 0)
            {
                _LightColor = LightColor;
                _byThreshold = Threshold;
                _byTick = Threshold;
                _Border = Border;
            }
            public void Tick()
            {
                _byTick += 3;
            }
            public void Render(CDrawer Drawer, int lightValue)
            {
                if (this._byTick>this._byThreshold)
                    Drawer.AddRectangle(lightValue % 16, lightValue/16, 1, 1, _LightColor, _Border, Color.Black);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listTrek = new List<TrekLight>();
            TrekWindow.Scale = 50;
            TrekWindow.BBColour = Color.Black;
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case 'd':
                    listTrek.Add(new TrekLight());
                    break;
                case 'f':
                    listTrek.Add(new TrekLight(Color.Red,127));
                    break;
                case 'g':
                    listTrek.Add(new TrekLight(RandColor.GetColor(),(byte)rng.Next(40,200),4));
                    break;
                case 'c':
                    if (listTrek.Count > 0)
                        listTrek.Remove(listTrek.Last());
                    break;
            }   
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TrekWindow.Clear();
            for (int i = 0; i < listTrek.Count; i++) 
            {
                //listTrek.ElementAt<TrekLight>(i).Tick();
                //listTrek.ElementAt<TrekLight>(i).Render(TrekWindow, i);
                listTrek[i].Tick();
                listTrek[i].Render(TrekWindow, i);
            }
        }
    }
}
