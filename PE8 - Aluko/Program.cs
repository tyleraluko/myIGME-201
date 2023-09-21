using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Practice Exercise #8
 * This practice exerxise contains three seperate console applications.
 * ...
 * ...
 * ...
 */
namespace PE8_Aluko {
    
    /*
     * Tyler Aluko
     * Console application to calculate z for range of x and y given the formula: z = 3y^2 + 2x - 1.
     */
    internal class CalculateZ {
        
        /*
         * Tyler Aluko
         * ...
         */
        static void Main(string[] args) {

            //range definitions
            double minX = -1.0;
            double maxX = 1.0;
            double minY = 1.0;
            double maxY = 4.0;

            //range incremental
            double increment = 0.1;

            //calculate array size
            int xSize = (int)( (maxX - minX) / increment ) + 1;
            int ySize = (int)( (maxY - minY) / increment ) + 1;

            //create 3D array
            double[,,] calculation = new double[xSize, ySize, 3];

            //store array values
            double x = minX;
            
            for (int i = 0; i < xSize; i++) { //nested for loop to calculate incremented values -> for x
                
                double y = minY;
                
                for (int j = 0; j < ySize; j++) { //calculate incremented values -> for y
                    
                    //original formula -> to code
                    double z = 3 * Math.Pow(y, 2) + 2 * x - 1; //using Math.Pow here to account for the y^2
                    
                    calculation[i, j, 0] = x; //stores x value
                    calculation[i, j, 1] = y; //stores y value
                    calculation[i, j, 2] = z; //stores z value
                    
                    y += increment;

                }

                x += increment;

            }

            //x, y, z values printed to console
            for (int i = 0; i < xSize; i++) { //nested for loop for all values of x
                
                for (int j = 0; j < ySize; j++) { //nested for loop for all values of y

                    Console.WriteLine($"x = {calculation[i, j, 0]}, y = {calculation[i, j, 1]}, z = {calculation[i, j, 2]}"); //print calculations to console

                }
            }

        }

    }

}
