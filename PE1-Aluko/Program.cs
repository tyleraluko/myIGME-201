//only using System for PE1
using System;
//the rest don't matter here (but i'll leave them anyways)
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201
 * Practice Exercise #1 - Hello World!
 * This practice exercise serves as a basic introduction to C# and some of its syntax.
 */
namespace PE1_Aluko {

    /*
     * class Program functionality
     * prints my name to console
     * declares local variable and prints to console
     * tests out some math equation syntax and prints to console
     * for loop prints "Hello World!" to console seven times
     */
    internal class Program {

        static void Main(string[] args) {
            
            Console.WriteLine("Tyler Aluko");

            int x = 7;
            Console.WriteLine(x);

            Console.WriteLine("Specified addition operation requires parentheses?" + (7 + 3));
            Console.WriteLine("Otherwise it'll just stick the numbers next to each other, right?" + 7 + 3);
            Console.WriteLine("And everything else goes in the written order?" + 3 + 7 * 7 + 3);
            Console.WriteLine("To make sure..." + 7 * 3 + 3 + 7);

            for(int i = 0; i < 7; i++) {
                Console.WriteLine("Hello World!");
            }

        }

    }

}
