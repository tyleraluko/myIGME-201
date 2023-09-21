using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Aluko_DoubleQuotes {
    
    /*
     * Tyler Aluko
     * IGME.201 - Practice Exercise #8
     */
    internal class Program {

        /*
         * Tyler Aluko
         * main functionality
         * prompts user for input sentence
         * splits sentence into individual words
         * for loop will add quotes around each word
         * rejoins string and prints results
         */
        static void Main(string[] args) {

            //prompts user input string
            Console.WriteLine("Please enter a sentence:");
            string input = Console.ReadLine();

            //splits string sentence into individual words
            string[] words = input.Split(' ');

            //for length of words in the sentence
            for (int i = 0; i < words.Length; i++) {
                
                words[i] = "\"" + words[i] + "\""; //add quotes around each word

            }

            //prints results
            string result = string.Join(" ", words); //string.Join will rejoin the original string to be printed
            Console.WriteLine("Your results:");
            Console.WriteLine(result);

        }

    }

}
