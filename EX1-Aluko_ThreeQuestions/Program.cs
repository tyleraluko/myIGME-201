using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Unit Test #1
 * This application recreates an executable of a three question trivia game.
 */
namespace EX1_Aluko_ThreeQuestions {
 
    internal class Program {

        /*
         * Tyler Aluko
         * main functionality
         * check if user wants to play again
         * asks user to choose question 1-3
         * switch statement holds questions/answers for all three questions (question 3 is impossible)
         * limits answer time to 5 secs
         * prints appropriate user input message
         * asks user to play again
         */
        static void Main(string[] args) {
            
            bool playAgain = true;

            while (playAgain) { //while game is running
                
                Console.WriteLine("Choose your question (1-3):");
                int questionChoice = int.Parse(Console.ReadLine());

                string correctAnswer = "";
                string userAnswer = "";

                //switch statement for all three questions contains question and correct answer
                switch (questionChoice) {

                    //question 1
                    case 1:
                        Console.WriteLine("You have 5 seconds to answer the following question:");
                        Console.WriteLine("What is your favorite color?");
                        correctAnswer = "black";
                        break;

                    //question 2
                    case 2:
                        Console.WriteLine("You have 5 seconds to answer the following question:");
                        Console.WriteLine("What is the answer to life, the universe and everything?");
                        correctAnswer = "42";
                        break;

                    //question 3
                    case 3:
                        Console.WriteLine("You have 5 seconds to answer the following question:");
                        Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
                        correctAnswer = "What do you mean? African or European swallow?"; //lol unless you're a god typer it's only possible if you copy/paste
                        break;

                    //invalid input
                    default:
                        Console.WriteLine("Invalid choice. Please select a question between 1 and 3.");
                        continue;

                }

                //five sec time limit
                var timer = new Timer(state => Console.WriteLine("Time's up!"), null, 5000, Timeout.Infinite);

                Console.Write("Your answer: ");
                userAnswer = Console.ReadLine();

                timer.Dispose();

                //prints appropriate message based on user input
                if (userAnswer.ToLower() == correctAnswer.ToLower()) {
                    Console.WriteLine("Well done!");
                }
                else {
                    Console.WriteLine($"Wrong! The answer is: {correctAnswer}");
                }

                //asks user to play again
                Console.WriteLine("Play again? (yes/no)");
                string playAgainResponse = Console.ReadLine().ToLower();
                if (playAgainResponse != "yes") {
                    playAgain = false;
                }

            }
        }
    }
}
