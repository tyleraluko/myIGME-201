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
    
    
    public partial class GameForm : Form
    {

        //may or may not need this let's see...
        private readonly int lowNumber;
        private readonly int highNumber;
        private readonly Random random = new Random();
        private readonly int targetNumber;
        private int secondsRemaining = 45;
        private int nGuesses = 0;

        public GameForm(int lowNumber, int highNumber)
        {
            
            InitializeComponent();

            this.lowNumber = lowNumber;
            this.highNumber = highNumber;
            targetNumber = random.Next(lowNumber, highNumber + 1);

            UpdateStatusLabel();
            
            timer.Start();

            AcceptButton = guessButton;

        }

        //guess button code
        /*
        private void GuessButton_Click(object sender, EventArgs e)
        {
            int guess;

            if (int.TryParse(guessTextBox.Text, out guess))
            {
                if (guess < lowNumber || guess > highNumber)
                {
                    MessageBox.Show("Please enter a number within the specified range.");
                }
                else
                {
                    nGuesses++;
                    CheckGuess(guess);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }
        */

        private void guessButton_Click_1(object sender, EventArgs e)
        {
            int guess;

            if (int.TryParse(guessTextBox.Text, out guess))
            {
                if (guess < lowNumber || guess > highNumber)
                {
                    MessageBox.Show("Please enter a number within the specified range.");
                }
                else
                {
                    nGuesses++;
                    CheckGuess(guess);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        private void CheckGuess(int guess)
        {
            if (guess == targetNumber)
            {
                timer.Stop();
                MessageBox.Show($"Congratulations! You guessed the correct number {targetNumber} in {nGuesses} turn(s).");
                this.Close();
            }
            else
            {
                string message = guess < targetNumber ? "Too low. Try again!" : "Too high. Try again!";
                UpdateStatusLabel(message);
            }
        }

        private void UpdateStatusLabel(string message = "")
        {
            statusLabel.Text = message;
        }

        private void timer__Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            if (secondsRemaining <= 0)
            {
                timer.Stop();
                MessageBox.Show("Time's up! The game is over.");
                this.Close();
            }

            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            int maxSeconds = 45;
            int currentProgress = (maxSeconds - secondsRemaining) * 100 / maxSeconds;
            toolStripProgressBar.Value = currentProgress;
        }

    }


}
