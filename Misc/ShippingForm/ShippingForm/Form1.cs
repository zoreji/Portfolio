/**********************************************************************
 * Program:     Shipping Form
 * Author:      Ervin Hernandez
 * Date:        2015 Jan 22
 * Class:       CMPE1600
 *********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShippingForm
{
    /// <summary>
    /// The Shipping Program does the calculation of a standard shipping application
    /// As the user input there amount, the program will calculate and alter to the 
    /// user desire price the program can project.
    /// </summary>
    public partial class Shipping_Form : Form
    {
        const double GST = 1.05;            // A constant variable that can be use in all methods that doesn't need to
        double userAmount = 0.0;            // be alter.
        double userTotal = 0.0;
        public Shipping_Form()
        {
            InitializeComponent();
        }

        private void Shipping_Form_Load(object sender, EventArgs e)
        {
            Amount_TB.Text = userAmount.ToString();
            ShippingCost();
        }

        //  This method check each radio button and check box if they are check 
        //  and ajust the correct total the user have apply in the UI
        private void ShippingCost()
        {
            userAmount = 0.0;
            try
            {
                userAmount = Convert.ToDouble(Amount_TB.Text);
                if (Amount_TB.Text == "")
                {
                    userAmount = 0.0;
                }
                if (Gold_RB.Checked)
                {
                    userAmount *= 1.05;
                }
                if (Express_RB.Checked)
                {
                    userAmount += 20;
                }
                userTotal = userAmount;
                if (!TaxCB.Checked)
                {
                    userTotal = userAmount * GST;
                }
                Total_TB.Text = userTotal.ToString("c");
            }
            catch
            {
                Total_TB.Text = userTotal.ToString("c");
                //userAmount = 0.0;
            }
        }

        // Note: The Shipping method is also in all the radio and check box checked change event to be
        //       be able to alter and change the the price in the UI.
        private void Amount_TB_TextChanged(object sender, EventArgs e)
        {
            ShippingCost();
        }
    }
}
