using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Unit Test #1
 * Now updated to function based on struct.
 * Console application checks if user is to receive a raise based on their name. 
 * The user to receive a raise in this instance is "Tyler Aluko".
 */
struct Employee {
    
    //starter variable declarations rewritten for struct
    public string sName;
    public double dSalary;

}
    
    internal class Program {

        static string myName = "Tyler Aluko";

        /*
         * Tyler Aluko
         * Main() functionality
         * variables from struct
         * prompts user for name
         * calls upon GiveRaise() function
         * if/else loop displays success message and adjusted salary if raise is true, and another message if raise is not
         */
        static void Main(string[] args) {
            
            //variables called from struct
            Employee employee;
            employee.dSalary = 30000;

            Console.WriteLine("Are you receiving a raise?");
            Console.WriteLine("Please enter your name: ");
            employee.sName = Console.ReadLine();

            //calls upon GiveRaise() function
            bool raise = GiveRaise(ref employee); //argument must be passed w/ ref keyword as is below in GiveRaise function

            //if/else loop checks if the user's name matches the name to receive raise
            if (raise) {
                Console.WriteLine($"Congratulations, {employee.sName}! You have received a raise!");
                Console.WriteLine($"Your salary has increased to: ${employee.dSalary:F2}.");
            }
            else {
                Console.WriteLine($"Unfortunately, {employee.sName}, you have not received a raise.");
                Console.WriteLine($"Your salary is: ${employee.dSalary:F2}.");
            }

        }


        /*
         * Tyler Aluko
         * GiveRaise() functionality
         * function to be called in Main() if myName = entered name
         * if loop checks if names match, and then adds $19999.99 to salary
         */
        static bool GiveRaise(ref Employee employee) { //employee is now only argument passed

            //if names match, carry out function
            if (employee.sName == myName) {
                employee.dSalary += 19999.99;
                return true;
            }

            return false;

        }

    }
