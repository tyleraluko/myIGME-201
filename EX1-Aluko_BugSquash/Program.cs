using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Unit Test #1
 * Bug fixes for a console application that calculates the value of (x ^ y).
 */
namespace UT1_BugSquash {

    class Program {

        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args) {

            string sNumber;
            int nX;
            
            //int nY -> syntax, missing semicolon (TA)
            int nY;

            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.); -> syntax, missing parentheses (TA)
            Console.WriteLine("This program calculates x ^ y.");

            do {

                Console.Write("Enter a whole number for x: ");

                //Console.ReadLine(); -> logic, sNumber not initialized-- causing sNumber parameter in while() to read as unassigned (TA)
                sNumber = Console.ReadLine();

            } while (!int.TryParse(sNumber, out nX));

            do {

                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();

            } 
            //while (int.TryParse(sNumber, out nX)); -> logic, nY variable left unassigned in Power() (TA)
            while(!int.TryParse(sNumber,out nY));

            // compute the exponent of the number using a recursive function
            //nAnswer = Power(nX, nY); -> logic, nAnswer w/o reference in non static field (TA)
            nAnswer = Power(nX, nY);

            //Console.WriteLine("{nX}^{nY} = {nAnswer}"); -> syntax, missing $ before quotes (TA)
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");

        }


        //int Power(int nBase, int nExponent) -> syntax, add public static (TA)
        public static int Power(int nBase, int nExponent) {

            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0) {

                // return the base case and do not recurse
                //returnVal = 0; -> logic, base case of zero will always return zero
                returnVal = 1;

            }
            else {

                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent - 1); -> logic, nExponent + 1 should be - 1
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;

            }

            //returnVal; -> syntax(?), missing return (TA)
            return returnVal;

        }

    }

}

