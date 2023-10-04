using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1_Aluko_SortSentences
{
    /*
     * Tyler Aluko
     * IGME.201 - Unit Test #1
     * Alters the number sorting application to instead sort words in a sentence.
     */
    class Program
    {
        // the definition of the delegate function data type
        delegate string[] sortingFunction(string[] words);

        static void Main(string[] args)
        {
            // declare the unsorted and sorted arrays
            string[] wordsUnsorted;
            string[] wordsSorted;

            // declare the delegate variable which will point to the function to be called
            sortingFunction sortWords;

        // a label to allow us to easily loop back to the start if there are input issues
        start:
            Console.WriteLine("Enter a sentence:");

            // read the sentence
            string inputSentence = Console.ReadLine();

            // split the sentence into an array of words
            string[] words = inputSentence.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries); //gets rid of extraneous characters in return string

            // prompt for <a>scending or <d>escending
            Console.Write("Ascending or Descending? ");
            string sDirection = Console.ReadLine();

            if (sDirection.ToLower().StartsWith("a"))
            {
                sortWords = new sortingFunction(SortWordsAscending);
            }
            else
            {
                sortWords = new sortingFunction(SortWordsDescending);
            }

            // sort the words
            wordsSorted = sortWords(words);

            // write the sorted array of words
            Console.WriteLine("The sorted words are:");
            foreach (string word in wordsSorted)
            {
                Console.Write($"{word} ");
            }

            Console.WriteLine();

            //ask if user wants to continue
            Console.Write("Do you want to continue? (Y/N) ");
            string continueInput = Console.ReadLine();
            if (continueInput.ToLower() == "y")
            {
                goto start;
            }
        }

        // sort words in ascending order
        static string[] SortWordsAscending(string[] words)
        {
            return words.OrderBy(word => word).ToArray();
        }

        // sort words in descending order
        static string[] SortWordsDescending(string[] words)
        {
            return words.OrderByDescending(word => word).ToArray();
        }
    }
}
