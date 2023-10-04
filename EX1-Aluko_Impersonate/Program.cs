using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Unit Test #1
 * Uses a delegate to impersonate the Math.Round function.
 */
namespace EX1_Aluko_Impersonate
{

    //define delegate w/ matching Math.Round signature
    delegate double MathRoundDelegate(double value, int digits);

    internal class Program
    {
        static void Main(string[] args)
        {
            //instance of delegate assigned Math.Round function
            MathRoundDelegate mathRoundDelegate = Math.Round;

            //ddelegate rounds number
            double roundedValue = mathRoundDelegate(7.777, 1);

            //print results to console
            Console.WriteLine("Rounded Value: " + roundedValue);
        }
    }

}