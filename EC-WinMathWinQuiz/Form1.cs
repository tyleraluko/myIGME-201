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
 * IGME.201 - Extra Credit, WinMath WinQuiz
 * A math quiz console application rewritten as a Windows Forms Application.
 * Prompts the user for the amount of questions they'd like to be asked, as well as the difficultty of the questions.
 * 
 * Notes:
 * Didn't get to finish this one, sorry! ;-;
 * Didn't get any useful comments in either. :/
 */
namespace EC_WinMathWinQuiz
{

    public partial class Form1 : Form
    {

        //user variables
        private string playerName;
        private int totalQuestions;
        private string difficultyLevel;
        private int correctAnswers;

        public Form1()
        {
            InitializeComponent();
        }

        //starts quiz
        private void MathQuizForm_Load(object sender, EventArgs e)
        {
            StartQuiz();
        }

        //...
        private void StartQuiz()
        {
            playerName = PromptForInput("What is your name?");
            totalQuestions = GetNumberOfQuestions();
            difficultyLevel = GetDifficultyLevel();

            for (int i = 0; i < totalQuestions; i++)
            {
                int questionNumber = i + 1;
                int num1 = GenerateRandomNumber(difficultyLevel);
                int num2 = GenerateRandomNumber(difficultyLevel);
                int correctAnswer = CalculateCorrectAnswer(num1, num2);

                string userAnswer = PromptForInput($"Question {questionNumber}: What is {num1} + {num2}?");

                if (IsInteger(userAnswer))
                {
                    
                    int userResponse = int.Parse(userAnswer);

                    if (userResponse == correctAnswer)
                    {
                        DisplayMessage($"Well done {playerName} !!!", Color.Blue);
                        correctAnswers++;
                    }
                    else
                    {
                        DisplayMessage($"I'm sorry {playerName}, the answer is {correctAnswer}.", Color.Red);
                    }

                }
                else
                {
                    i--; //retry same question
                    DisplayMessage($"Please enter an integer, {playerName}", Color.Black);
                }
            }

            DisplayResults();
            AskToPlayAgain();
        }

        //...
        private void DisplayResults()
        {
            double percentage = (double)correctAnswers / totalQuestions * 100;
            DisplayMessage($"You got {correctAnswers} out of {totalQuestions} correct, which is a score of {percentage:F2}%.", Color.Black);
        }

        //...
        private void AskToPlayAgain()
        {
            DialogResult result = MessageBox.Show("Do you want to play again?", "Play Again", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetQuiz();
                StartQuiz();
            }
            else
            {
                this.Close();
            }
        }

        //...
        private void ResetQuiz()
        {
            totalQuestions = 0;
            correctAnswers = 0;
        }

        //...
        private string PromptForInput(string prompt)
        {
            return MessageBox.Show(prompt, "Math Quiz", MessageBoxButtons.OKCancel).ToString();
        }

        //...
        private int GetNumberOfQuestions()
        {
            string input = PromptForInput("How many questions?");
            int numberOfQuestions;

            while (!int.TryParse(input, out numberOfQuestions))
            {
                DisplayMessage($"Please enter an integer, {playerName}.", Color.Black);
                input = PromptForInput("How many questions?");
            }

            return numberOfQuestions;
        }

        //...
        private string GetDifficultyLevel()
        {
            string[] difficultyLevels = { "easy", "medium", "hard" };
            string input = PromptForInput("Enter the difficulty level (easy, medium, or hard):").ToLower();

            while (Array.IndexOf(difficultyLevels, input) == -1)
            {
                DisplayMessage($"Invalid difficulty level, {playerName}. Please enter easy, medium, or hard.", Color.Black);
                input = PromptForInput("Enter the difficulty level (easy, medium, or hard):").ToLower();
            }

            return input;
        }

        //...
        private int GenerateRandomNumber(string difficulty)
        {
            Random random = new Random();

            switch (difficulty)
            {
                case "easy":
                    return random.Next(1, 11);
                case "medium":
                    return random.Next(1, 101);
                case "hard":
                    return random.Next(1, 1001);
                default:
                    return 0;
            }
        }

        //...
        private int CalculateCorrectAnswer(int num1, int num2)
        {
            return num1 + num2;
        }

        //...
        private bool IsInteger(string input)
        {
            return int.TryParse(input, out _);
        }

        //...
        private void DisplayMessage(string message, Color color)
        {
            richTextBoxOutput.SelectionColor = color;
            richTextBoxOutput.AppendText(message + "\n");
            richTextBoxOutput.SelectionColor = richTextBoxOutput.ForeColor;
        }

    }

}
