using System;

namespace SquashTheBugs
{
    /*
     * Debugger - Tyler Aluko
     * IGME.201 - Practice Exercise #2
     * Squash the bugs!
     * This one really stumped me. :/
     * Going to need more time to review debugging and syntax for C# so I can figure things out for next time.
     */
    
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //int i = 0 -> syntax, missing semicolon
            int i = 1;

            // loop through the numbers 1 through 10
            for ( i = 1; i < 10; ++i )
            {
                // declare string to hold all numbers
                string allNumbers = null;

                //testing stuff
                //i = i + 1;

                // output explanation of calculation
                //Console.Write(i + "/" + i - 1 + " = "); -> syntax, missing parentheses -> logic error, only divides odd numbers through ten
                Console.WriteLine(i + "/" + (i - 1) + "=");

                // output the calculation based on the numbers
                //test w/ try/catch
                //Console.WriteLine(i / (i-1));
                try
                {
                    Console.WriteLine(i / (i - 1));
                } 
                catch (DivideByZeroException) {
                    Console.WriteLine("Invalid"); //zero can't be divided, prints invalid instead of crashing
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter -> logic error, this increments i twice per loop; once inside for(), and again here
                //i = i + 1;

               //Console.WriteLine("These numbers have been processed: ", i);
            }

            // output all numbers which have been processed
            //Console.WriteLine("These numbers have been processed: " allNumbers); //syntax, missing comma -> run-time, cannot use allNumbers
            Console.WriteLine("These numbers have been processed: ", i);
        }
    }
}
