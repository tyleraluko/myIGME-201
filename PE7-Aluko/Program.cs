using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Practice Exercise #7
 * Creating a program for six Mad Libs stories! Main function handles game start up, while Play function handles game mechanics.
 * A few Mad Libs stories aren't functioning properly, but the program itself should be working as intended. :)
 */
namespace PE7_Aluko
{

    internal class Program {

        /*
         * Tyler Aluko
         * main functionality
         * asks if user wants to play mad libs
         * if yes, runs game in new PlayMabLibs() method
         * if no, ends program
         * if invalid, prints error and re-prompts
         */
        static void Main(string[] args) {

            //loop checks for valid user input
            while (true) {

                //ask user to play mad libs
                Console.WriteLine("Do you want to play Mad Libs?");
                string userChoice = Console.ReadLine().ToLower(); //to make case non-sensitive, convert input to lowercase

                //nested if loop executes based on answer
                if (userChoice == "yes") {
                    PlayMadLibs(); //runs mad libs function if answered "yes"
                }
                else if (userChoice == "no") {
                    Console.WriteLine("Ending program. Goodbye."); //prints message
                    break; //ends loop
                }
                else {
                    Console.WriteLine("Input invalid. Please enter 'yes' or 'no'."); //prints error message
                }

            }

        }


        /*
         * Tyler Aluko
         * PlayMadLibs() functionality
         * from mad libs template file path
         * validates correct path for testing
         * stream reader uses filePath
         * reads stories string to end of file
         * prompts user for name to be used in title
         * prompts mad libs story number
         * prompts user for each entry word in story
         * prints final results
         */
        static void PlayMadLibs() {


            //hardcoded mad libs template path
            string filePath = @"c:\\templates\\MadLibsTemplate.txt";

            //validates correct file path (only needed for testing)
            if (!File.Exists(filePath)) { //File.Exists checks for file directory
                Console.WriteLine("Mad Libs Template file not found."); //displays error message
                return;
            }

            //still not completely sure how stream reader works but let's give this a try
            using (StreamReader reader = new StreamReader(filePath)) {

                //instead of reading line by line, found this ReadToEnd() method to read until the end of the file
                string[] stories = reader.ReadToEnd().Split('\n'); //then parse w/ Split()

                //prompts user name
                Console.WriteLine("Please enter your first name.");
                string userName = Console.ReadLine();

                //prompts mad libs story
                Console.WriteLine("Choose a story by entering a number (1-" + stories.Length + "): ");
                int storyChoice;
                
                while (!int.TryParse(Console.ReadLine(), out storyChoice) || storyChoice < 1 || storyChoice > stories.Length) { //can be used for any number of stories
                    Console.WriteLine("Invalid input. Please enter a valid number."); //error message if input not within story choice bounds
                }

                Console.WriteLine("Choose some words for the Mad Libs story!"); //message to start filling in story

                string[] storyWords = stories[storyChoice - 1].Split(' ');
                string resultString = ""; //will hold final result
                
                //for each loop reads each word in story
                foreach (string word in storyWords) {
                    if (word == "\\n") { //if word is line break
                        resultString += "\n"; //to resultString
                    }
                    else if (word.StartsWith("{") && word.EndsWith("}")) { //else if word is chooseable by user
                        string prompt = word.Trim('{', '}').Replace("_", " "); //remove brackets in results, replace underscore w/ space
                        Console.Write(prompt + ": "); //prompts new user entry
                        string userWord = Console.ReadLine(); //stores user entry
                        resultString += userWord + " "; //adds to results
                    }
                    else {
                        resultString += word + " ";
                    }
                }

                Console.WriteLine(userName + "'s Mad Libs story:"); //story title uses user name
                Console.WriteLine(resultString); //prints final results
            }

        }

    }
}