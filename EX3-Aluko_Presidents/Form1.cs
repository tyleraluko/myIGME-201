using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * Tyler Aluko
 * IGME.201 - Unit Test #3
 * Reconstruction of the President.exe application w/ pseudo-code and list of controls.
 */
namespace EX3_Aluko_Presidents


{
    public partial class Form1 : Form
    {

        //declares necessary controls
        private RadioButton[] presidentRadioButtons;
        private TextBox[] presidentTextBoxes;
        private RadioButton[] filterRadioButtons;

        public Form1()
        {
            InitializeComponent();
            InitializeControls(); //added - from private void
        }

        private void InitializeControls()
        {
            //intialize 16 president radio and text controls
            presidentRadioButtons = new RadioButton[15];
            presidentTextBoxes = new TextBox[15];

            for (int i = 0; i < 15; i++)
            {
                presidentRadioButtons[i] = new RadioButton();
                presidentRadioButtons[i].Text = GetPresidentName(i); //GetPresidentName method
                presidentRadioButtons[i].Location = new System.Drawing.Point(20, 20 + i * 30);
                presidentRadioButtons[i].CheckedChanged += PresidentRadioButton_CheckedChanged;

                presidentTextBoxes[i] = new TextBox();
                presidentTextBoxes[i].Location = new System.Drawing.Point(150, 20 + i * 30);
                presidentTextBoxes[i].Enabled = false; //disable until radio button selected

                this.Controls.Add(presidentRadioButtons[i]);
                this.Controls.Add(presidentTextBoxes[i]);
            }

            //initialize 5 filter radio controls
            filterRadioButtons = new RadioButton[5];

            for (int i = 0; i < 5; i++)
            {
                filterRadioButtons[i] = new RadioButton();
                filterRadioButtons[i].Text = GetFilterName(i); //GetFilterName method
                filterRadioButtons[i].Location = new System.Drawing.Point(20 + i * 120, 300);
                filterRadioButtons[i].CheckedChanged += FilterRadioButton_CheckedChanged;

                this.Controls.Add(filterRadioButtons[i]);
            }

            //initialize president PictureBoxes
            PictureBox presidentPictureBox = new PictureBox();
            presidentPictureBox.Location = new System.Drawing.Point(300, 20);
            presidentPictureBox.Size = new System.Drawing.Size(200, 200);
            this.Controls.Add(presidentPictureBox);

            //initialize wikipedia page PictureBox
            PictureBox wikipediaPictureBox = new PictureBox();
            wikipediaPictureBox.Location = new System.Drawing.Point(300, 240);
            wikipediaPictureBox.Size = new System.Drawing.Size(200, 200);
            this.Controls.Add(wikipediaPictureBox);

        }

        //president radio button selection method
        private void PresidentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;

            //enable corresponding text box on president radio button selection
            for (int i = 0; i < 15; i++)
            {
                if (presidentRadioButtons[i] == selectedRadioButton)
                {
                    presidentTextBoxes[i].Enabled = true;
                }
                else
                {
                    presidentTextBoxes[i].Enabled = false;
                    presidentTextBoxes[i].Text = ""; //disable other text boxes
                }
            }

            //display wikipedia page and president image of selected president
            string selectedPresident = selectedRadioButton.Text;
            DisplayWikipediaPage(selectedPresident);
            DisplayPresidentImage(selectedPresident);
        }

        private void FilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //implement president radio button filter logic
        }

        private void DisplayWikipediaPage(string presidentName)
        {
            //implement wikipedia page display logic
        }

        private void DisplayPresidentImage(string presidentName)
        {
            //implement presdent image display logic
        }

        private string GetPresidentName(int index)
        {
            //implement logic to get president name based on index
            switch (index)
            {
                case 0: return "Benjamin Harrison";
                case 1: return "Franklin D Roosevelt";

                //add cases for other Presidents
                default: return "";
            }

        }

        private string GetFilterName(int index)
        {
            //implement logic to get filter name based on index
            switch (index)
            {
                case 0: return "All";
                case 1: return "Democrat";
                //add cases for other filters
                default: return "";
            }
        }

    }


}
