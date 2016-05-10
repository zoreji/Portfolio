using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VU_Application
{
    public partial class Form1 : Form
    {
        int counter = 0;
        Random rng = new Random();
        List<int> randomVals = new List<int>();
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            for (int i = 0; i < 1000; i++)
            {
                randomVals.Add(rng.Next(0, 161));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //if (counter > 999)
            //    counter = 0;
            //testMeter1.degrees = randomVals[counter];
            //counter++;

            if (counter > 110)
                counter = 0;
            //testMeter1.degrees = counter;



            //testStatus1.Value = counter;
            //testStatus1.Value = counter;

            counter += 5;


        }
    }
}
