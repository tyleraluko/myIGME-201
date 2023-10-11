using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX1_Aluko_Salary {
    
    /*
     * Tyler Aluko
     * IGME.201 - Unit Test #1
     * Console application checks if user is to receive a raise based on their name. 
     * The user to receive a raise in this instance is "Tyler Aluko".
     */
    internal class Program {

        static string myName = "Tyler Aluko"; //initially wasn't sure if this was supposed to literally be "YourName" or my actual name haha

        /*
         * Tyler Aluko
         * Main() functionality
         * declares name and starter salary variables
         * prompts user to enter name
         * calls upon GiveRaise() function
         * if/else loop displays success message and adjusted salary if raise is true, and another message if raise is not
         */
        static void Main(string[] args) {
            
            //starter variable declarations
            string sName;
            double dSalary = 30000;

            Console.WriteLine("Are you receiving a raise?");
            Console.WriteLine("Please enter your name: ");
            sName = Console.ReadLine();

            //calls upon GiveRaise() function
            bool raise = GiveRaise(sName, ref dSalary);

            //if/else loop checks if the user's name matches the name to receive raise
            if (raise) {
                Console.WriteLine($"Congratulations, {sName}! You have received a raise!");
                Console.WriteLine($"Your salary has increased to: ${dSalary:F2}.");
            }
            else {
                Console.WriteLine($"Unfortunately, {sName}, you have not received a raise.");
                Console.WriteLine($"Your salary is: ${dSalary:F2}.");
            }

        }

        /*
         * Tyler Aluko
         * GiveRaise() functionality
         * function to be called in Main() if myName = entered name
         * if loop checks if names match, and then adds $19999.99 to salary
         */
        static bool GiveRaise(string name, ref double salary) {
            
            //if names match, carry out function
            if (name == myName) {
                salary += 19999.99;
                return true;
            }

            return false;

        }

    }

}
