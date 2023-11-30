using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE17_Aluko
{
    
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            //event handlers
            lowTextBox.KeyPress += TextBox_KeyPress;
            highTextBox.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only digits + control keys
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //added to start button pseudo-code
        private void startButton_Click(object sender, EventArgs e)
        {
            bool bConv;
            int lowNumber = 0;
            int highNumber = 0;

            // convert the strings entered in lowTextBox and highTextBox
            // to lowNumber and highNumber Int32.Parse
            bConv = Int32.TryParse(lowTextBox.Text, out lowNumber);
            bConv &= Int32.TryParse(highTextBox.Text, out highNumber); //or (&=)...!

            // if not a valid range
            if (!bConv || lowNumber >= highNumber)
            {
                // show a dialog that the numbers are not valid
                MessageBox.Show("The numbers are invalid.");
            }
            else
            {
                // otherwise we're good
                // create a form object of the second form 
                // passing in the number range
                GameForm gameForm = new GameForm(lowNumber, highNumber);

                // display the form as a modal dialog, 
                // which makes the first form inactive
                gameForm.ShowDialog();
            }
        }

    }


}
