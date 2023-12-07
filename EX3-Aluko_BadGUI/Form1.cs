using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



/*
 * Tyler Aluko
 * IGME.201 - Unit Test #3
 * This Windows Forms App is a math quiz with quesitonable UI choices.
 */
namespace EX3_Aluko_BadGUI
{
    public partial class Form1 : Form
    {

        private readonly Thread uiThread;
        private int countdown = 30;
        
        public Form1()
        {
            InitializeComponent();

            //initialize uiThread
            uiThread = new Thread(UpdateUI);
            uiThread.Start();

        }

        //updates UI w/ random modifications to various elements
        private void UpdateUI()
        {
            while (true)
            {
                //changes colors randomly
                RandomColor();

                //moves buttons randomly
                RandomButtons();

                //modifies text fields
                ModTextFields();

                //some event handlers
                checkAnswersButton.Click += new System.EventHandler(CheckAnswersButton_Click);
                timer1.Tick += new System.EventHandler(TimerTick);

            }
        }

        //randomizes background color
        private void RandomColor()
        {
            Random random = new Random();
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);
            this.BackColor = Color.FromArgb(r, g, b); ///send to background
        }

        //shifts location of buttons 1, 2, and 3 at random
        private void RandomButtons()
        {
            Random random = new Random();
            int deltaX = random.Next(-5, 6);
            int deltaY = random.Next(-5, 6);

            button1.Location = new Point(button1.Location.X + deltaX, button1.Location.Y + deltaY);
            button2.Location = new Point(button2.Location.X + deltaX, button2.Location.Y + deltaY);
            button3.Location = new Point(button3.Location.X + deltaX, button3.Location.Y + deltaY);
        }

        //change this one
        private void ModTextFields()
        {
            
            Random random = new Random();
            
            if (random.Next(2) == 0)
            {
                // Drop the letter 'e' randomly from labels
                label1.Text = label1.Text.Replace("e", "");
                label2.Text = label2.Text.Replace("e", "");
                label3.Text = label3.Text.Replace("e", "");
            }
            else
            {
                // Change font randomly
                Font font = new Font("Arial", random.Next(10, 20), FontStyle.Bold);
                label1.Font = font;
                label2.Font = font;
                label3.Font = font;
            }

        }

        //performs incorrect calculations by adding a random amount of numbers
        private void CheckAnswersButton_Click(object sender, EventArgs e)
        {
            //performs incorrect calculations
            int result = 10 + 5; // Incorrect answer
            MessageBox.Show($"Your answer is: {result}", "Result");
        }

        private void TimerTick(object sender, EventArgs e)
        {
            countdown--;

            if (countdown <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Time's up!", "Result");
            }
        }

        //so u don't crash >:(
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            uiThread.Abort();
        }

    }
}
