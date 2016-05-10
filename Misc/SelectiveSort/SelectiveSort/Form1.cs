/**************************************************************************
 *  Selective Sort
 *  Date:   2015 Jan 15
 *  Author: Ervin Hernandez
 *  Class:  CMPE1600
 **************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectiveSort
{
    /// <summary>
    /// The Selective Sort is a program that sort a set of 20 random generated Floats of numbers
    /// Each random generated number will be store into a array where it will be sorted by
    /// finding the lowest number and placing the number to the start of the array
    /// It will continue to selectively sort the array until the array is sorted in
    /// ascending order.
    /// </summary>
    public partial class Sort_Main_Form : Form
    {
        // These Variables are declare globally in the class so that the non-static methods
        // are able to alter and aquire the variables.
        float[] UserArray = null;
        Random RNG = new Random();

        public Sort_Main_Form()
        {
            InitializeComponent();
        }

        private void Sort_BT_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (UserArray != null)                                      // This Statement Insure that the array contains floats values
            {
                UserArray = Sort(UserArray);
                int num = 1;             
                foreach (double i in UserArray)
                {
                    listBox1.Items.Add(num.ToString() + ")\t" + i.ToString("f1"));
                    num++;
                }
            }
            else
            {
                listBox1.Items.Add("Error Array Empty");
            }
        }

        private void Generate_BT_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            UserArray = RandomArray(UserArray);
            int num = 1;
            foreach (double i in UserArray)
            {
                listBox1.Items.Add(num.ToString() + ")\t" + i.ToString("f1"));
                num++;
            }
        }

        private void Reset_BT_Click(object sender, EventArgs e)
        {
            UserArray = RandomArray(UserArray);
            listBox1.Items.Clear();
        }
        
        // Generate the range and values for the array
        // then assign each values into the array
        private float[] RandomArray(float[] Array)
        {
            double temp = 0;
            Array = new float[20];
            for (int i = 0; i <= Array.Length - 1; i++)
            {
                temp = (-2.4 + (RNG.NextDouble() * (9.8 - (-2.4))));    // Sets the minimal and Maximum for the random due to Random NextDouble Can only
                Array[i] = Convert.ToSingle(temp);                      // generate number between 0.0 to 1.0
            }
            return Array;
        }

        // A Sort method that goes through the generated array and sort the array in ascending order
        // by placing the lowest values in the array and placing it in the front of the array
        private float[] Sort(float[] Array)
        {
            int index = 0;
            float temp = 0;
            for (int i = 0; i <= Array.Length - 1; i++) 
            {
                index = LowestNum(Array, i);                            // goes to the LowestNum method to find the index of the lowest number it
                temp = Array[index];                                    // in the generated array
                Array[index] = Array[i];
                Array[i] = temp;
                //Console.WriteLine(Array[i]);                          // check if it did sort in the console
            }
            return Array;
        }

        // the method that goes through the array and find the index of the lowest array that
        // have been generated
        private int LowestNum(float[] Array, int index)                 // Index variable is the index were the position of the next lowest number
        {                                                               // will be place next
            int lowNum = index;
            for (int i = index; i <= Array.Length - 1; i++)
            {
                if (Array[i] < Array[lowNum])
                {
                    lowNum = i;
                }
            }
            return lowNum;
        }
    }
}
