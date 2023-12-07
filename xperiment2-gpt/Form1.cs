using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xperiment2_gpt
{
    public partial class Form1 : Form
    {

        private Timer timer;
        private int remainingTime;
        
        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Initialize Presidents Radio Buttons and Text Boxes
            string[] presidents = {"Benjamin Harrison", "Franklin D Roosevelt", "William J Clinton", "James Buchanan",
                "Franklin Pierce", "George W Bush", "Barack Obama", "John F Kennedy", "William McKinley", "Ronald Reagan",
                "Dwight D Eisenhower", "Martin Van Buren", "George Washington", "John Adams", "Theodore Roosevelt", "Thomas Jefferson"};

            for (int i = 0; i < presidents.Length; i++)
            {
                RadioButton radioButton = new RadioButton
                {
                    Text = presidents[i],
                    Location = new System.Drawing.Point(20, 30 * i + 20),
                    Parent = this
                };

                TextBox textBox = new TextBox
                {
                    Location = new System.Drawing.Point(200, 30 * i + 20),
                    Tag = i, // Tag is used to store the index of the president
                    Parent = this
                };
                textBox.KeyPress += TextBox_KeyPress; // Add event handler to validate input
            }

            // Initialize Timer and Progress Bar
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            ProgressBar progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 60,
                Value = 60,
                Width = 400,
                Height = 20,
                Location = new System.Drawing.Point(20, 550),
                Parent = this
            };

            // Initialize Filters Radio Buttons
            string[] filters = { "All", "Democrat", "Republican", "Democratic-Republican", "Federalist" };

            for (int i = 0; i < filters.Length; i++)
            {
                RadioButton filterRadioButton = new RadioButton
                {
                    Text = filters[i],
                    Location = new System.Drawing.Point(20 + 100 * i, 600),
                    Tag = i, // Tag is used to store the filter index
                    Parent = this
                };
                filterRadioButton.CheckedChanged += FilterRadioButton_CheckedChanged;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits and backspace in the text box
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTime--;
            // Update progress bar
            ((ProgressBar)Controls["ProgressBar"]).Value = remainingTime;

            if (remainingTime == 0)
            {
                timer.Stop();
                MessageBox.Show("Time's up!");
            }
        }

        private void FilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Implement logic to filter the president options based on the selected filter
            // You can use the Tag property of the filter radio buttons to identify the selected filter
            // Update the list of president options accordingly
            throw new NotImplementedException();
        }

        private void PresidentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Implement logic to show the Wikipedia mobile web page and president image
            // You can use the Text property of the selected president radio button to identify the selected president
            throw new NotImplementedException();
        }

        private void StartTimer()
        {
            remainingTime = 60;
            timer.Start();
        }


    }
}
