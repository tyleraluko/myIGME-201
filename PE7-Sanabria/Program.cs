using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MadLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setting up starting variables
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;
            string finalStory = "";
            string resultString = "";
            //Setting up the StreamReader for the external text file
            StreamReader input;


            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            string textLine = null;
            while ((textLine = input.ReadLine()) != null)
            {
                ++numLibs;
            }
            input.Close();

            string[] madLibs = new string[numLibs];
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            textLine = null;
            while ((textLine = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = textLine;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }
            input.Close();
            //Prompting user for which they want to play. 
            bool acceptableValue = false;

            while (acceptableValue == false)
            {
                Console.WriteLine("Which Mad Libs would you like to play? 1-" + numLibs);

                if (nChoice >= numLibs)
                {
                    Console.WriteLine("This isn't a permitted value.");
                    continue;
                }
                else if (nChoice <= numLibs)
                {
                    nChoice = int.Parse(input.ReadLine());
                    acceptableValue = true;
                }
                else
                {
                    Console.WriteLine("Please enter a proper number.");
                    continue;
                }
                }
            }


            string[] words = madLibs[nChoice].Split(' ');

            foreach (string word in words)
            {

                if (word[0] == '{')
                {
                    string replacementWord = word.Replace("{", "").Replace("}", "").Replace("_", "");
                    //Prompts user for a replacement word
                    Console.Write("Input a {0}: ", replacementWord);
                    //Adds the response into the string
                    finalStory += Console.ReadLine();
                }
                // else append word to the result string
                else
                {
                    finalStory += word;
                }
                resultString = finalStory;

            }
        }
    }
}