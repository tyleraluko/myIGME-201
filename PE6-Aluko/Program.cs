using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6_Aluko {
    /*
     * Tyler Aluko
     * IGME.201 - Practice Exercise #6
     * Number guessing game; The program will generate a random number (0-100), and the user will attempt to guess it!
     */
    static class Program {
        
        /*
         * Tyler Aluko
         * main function
         * generates random number - loop variables hold max attempt number and current used attempts
         * loop runs while user attempts are less than max attempts - initiates game, allows user input
         * nested if loop parses user input and checks for valid entry
         * if not invalid, increment user attempts
         * else conditions if user input is too low/high
         * else conditions if user runs out of attempts
         */
        static void Main(string[] args) {
            
            //creates new random object
            Random rand = new Random();
            int randomNumber = rand.Next(0, 101); //generate random number between 0 (inclusive) and 101 (exclusive)
            //Console.WriteLine(randomNumber); //displays the random number for testing

            //loop variables check for max amount of user attempts and the current amount of attempts
            int attemptsMax = 8; //max amount of user attempts
            int attemptsNow = 0; //currently amount of user attempts

            //loop checks for valid user inputs - eight chances
            while(attemptsNow < attemptsMax) {
                Console.WriteLine($"Guess a number between 0 and 100. Attempts used:{attemptsNow}"); //displays to user the number of used attempts
                string input = Console.ReadLine(); //user input

                //nested if loop checks for valid user attempts 0-100
                if(int.TryParse(input, out int userInput)) { //parse user input
                    
                    if(userInput < 0 || userInput > 100) { //user input tracking
                        
                        Console.WriteLine("Invalid input. Please guess a number between 0 and 100."); //displays error message if input out of bounds (does not use attempt)
                    
                    } else {
                        
                        //if not invalid, increment used attempts
                        attemptsNow++;
                        
                        //further nested if loop gives user hits or displays correct number
                        if(userInput == randomNumber) {
                            
                            //correct input message
                            Console.WriteLine($"Guess correct! You guessed {randomNumber} in {attemptsNow} attempts.");
                            return;

                        } else if (userInput < randomNumber) {
                            
                            //low input message
                            Console.WriteLine("Incorrect. Low input.");

                        }  else if (userInput > randomNumber) {
                            
                            //high input message
                            Console.WriteLine("Incorrect. High input.");

                        }
                    }
                }

                //error message for invalid input
                else {
                    Console.WriteLine("Please enter a valid character."); //error message if not a number
                }

            }

            //final error - user out of attempts
            Console.WriteLine($"You have run out of attempts. The correct number was: {randomNumber}!");

        }

    }
}
