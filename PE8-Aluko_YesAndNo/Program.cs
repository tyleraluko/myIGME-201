using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Practice Exercise #8
 * Console application will accept a string from the user w/ yes or no, and replace them w/ each other.
 */
namespace PE8_Aluko_YesAndNo {
    
    internal class Program {

        /*
         * Tyler Aluko
         * main functionality
         * prompts user input string
         * uses Replace function to (attempt to) replace no and yes case-insensitively
         * prints resulting statement
         */
        static void Main(string[] args) {
            
            //prompts user input
            Console.WriteLine("Please enter a string including the word 'no' or 'yes'':");
            string userInput = Console.ReadLine();

            string result = Replace(userInput, "no", "yes");

            //resulting string
            Console.WriteLine("Did you mean yes or no? :");
            Console.WriteLine(result);

        }

        /*
         * Tyler Aluko
         * replaces no w/ yes and vice-versa (not working for yes)
         */
        static string Replace(string userInput, string oldText, string newText) {
            
            //not case insensitive, but will replace lowercase no
            return userInput.Replace(oldText, newText);

        }

    }

}
