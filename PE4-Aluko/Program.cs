using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4_Aluko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 - truth table
            var var1 = 11;
            var var2 = 7;
            bool under10 = (var1 > 10) ^ (var2 > 10);
            Console.WriteLine(under10);
        }
    }
}
