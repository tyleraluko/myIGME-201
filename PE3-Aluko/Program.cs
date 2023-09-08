using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Practice Exercise #3
 * Testing space for PE3.
 */
namespace PE3_Aluko {
    internal class Program {

        static void Main(string[] args) {
            
            //find values
            int num1 = 2;
            int num2 = 4;
            int num3 = 5;
            Console.WriteLine(num1 = num1 * num3);
            Console.WriteLine(num2 = num1 / num2);
            Console.WriteLine(num3 = num3 % num2);

            //does this compile?
            double amountOfMoney = 3.50;
            Console.WriteLine(amountOfMoney);

            //output?
            Console.Write("Hi there");
            Console.Write("David");

            Console.Out.WriteLine("50 plus 25 is " + 50 + 25);

            //produce specified output w/ code
            Console.WriteLine("Please type your name below.");
            string Name = Console.ReadLine();
            Console.WriteLine("Your name is " + Name + "!");

            //name string
            string myName = "Tyler ";
            string myLastName = "Aluko";
            string myFullName = myName + myLastName;
            Console.WriteLine(myFullName);

            //parse double
            Console.WriteLine("Please enter a number with a decimal precision of 2.");
            string input = Console.ReadLine();
            Double.Parse(input);
            double newNum = 55.0;
            Console.WriteLine(input + newNum);

            //correct userInput string?
            string userInput = Console.ReadLine();
            int userNumber = int.Parse(userInput);
            Console.WriteLine(userNumber);

            //console input product
            string numOne = Console.ReadLine();
            string numTwo = Console.ReadLine();
            string numThree = Console.ReadLine();
            string numFour = Console.ReadLine();
            int conNumOne = int.Parse(numOne);
            int conNumTwo = int.Parse(numTwo);
            int conNumThree = int.Parse(numThree);
            int conNumFour = int.Parse(numFour);
            Console.WriteLine(conNumOne * conNumTwo * conNumThree * conNumFour);

            //why does ReadLine need to be at the end to see the remaining console output?
            Console.ReadLine();
        }
    }
}
