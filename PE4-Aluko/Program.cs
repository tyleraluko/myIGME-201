using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PE4_Aluko {

    /*
     * Tyler Aluko
     * IGME.201 - Practice Exercise #4
     * Class generates Mandelbrot sets in console.
     * I think I broke it... :(
     */
    class Mandelbrot {
        
        /*
         * method - Main()
         * calls Mandelbrot generator
         * parameter - args
         * reads arguments passed from console
         */
        [STAThread]
        static void Main(string[] args) {

            //declare variables
            //double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            //modified application variables
            double uImageStart, uImageEnd, realImageStart, realImageEnd;
            int iterationsCap = 40;

            //user input image limits
            Console.Write("Please enter a starting value. (realCoord)"); //start value
            
            if (!double.TryParse(Console.ReadLine(), out uImageStart)) {
                
                Console.WriteLine("Input invalid. Please enter a valid input.");
                return;

            }

            Console.Write("Please enter an ending value. (realCoord)"); //end value

            if (!double.TryParse(Console.ReadLine(), out uImageEnd) || uImageEnd <= uImageStart) {
                
                Console.WriteLine("Input invalid. Please enter an ending value greater than the starting value.");
                return;

            }

            Console.Write("Please enter a starting value. (imagCoord)"); //start value
            if (!double.TryParse(Console.ReadLine(), out realImageStart)) {
                
                Console.WriteLine("Input invalid. Please enter a valid input.");
                return;

            }

            Console.Write("Please enter an ending value. (imagCoord)"); //end value

            if (!double.TryParse(Console.ReadLine(), out realImageEnd) || realImageEnd >= realImageStart) {
                
                Console.WriteLine("Input invalid. Please enter an ending value greater than the starting value.");
                return;

            }

            //increment calculation
            double realIncrement = (uImageEnd - uImageStart) / 80;
            double imageIncrement = (realImageStart - realImageEnd) / 48;

            //cycle full image coodinates
            for (double imagCoord = realImageStart; imagCoord >= realImageEnd; imagCoord += imageIncrement) {

                for (double realCoord = uImageStart; realCoord <= uImageEnd; realCoord += realIncrement) {

                    //initialize more variables
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    
                    //iterate w/ while loop - get value of x*x + y*y
                    while ((arg < 4) && (iterations < iterationsCap)) { //40 max iterations

                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;

                    }

                    //chooses character output
                    switch (iterations % 4) {
                        
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;

                    }
                }

                //escape sequence
                Console.Write("\n");

            }

        }
    }
}
