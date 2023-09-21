using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Aluko_ReverseStrings
{
    /*
    * Tyler Aluko
    * Console application to accept string from user and reverse it.
    */
    internal class StringReversal {
        
        /*
         * Tyler Aluko
         * main functionality
         * entry point for UserInputString function
         */
        static void Main(string[] args) {
            
            //entry point
            UserInputString();

        }

        /*
         * Tyler Aluko
         * UserInputString functionality
         * prompts user to input string
         * reverses input from ReverseString function
         * prints reversed string
         */
        static void UserInputString() {

            //prompt user to input string
            Console.WriteLine("Please input any string.");
            string userString = Console.ReadLine();

            //reverse input from new function
            string reverse = ReverseString(userString);

            //printed reversed string
            Console.WriteLine("Here is your reversed string: " + reverse);

        }

        /*
         * Tyler Aluko
         * ReverseString functionality
         * to be used in UserInputString function
         * creates array from userString characters
         * reverses characters
         * returns new string
         */
        static string ReverseString(string userString) {
            
            char[] charArray = userString.ToCharArray(); //creates array of characters in the string
            Array.Reverse(charArray); //reverses characters in string
            return new string(charArray); //returns new string

        }

    }

}
