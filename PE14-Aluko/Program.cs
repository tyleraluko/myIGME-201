using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Tyler Aluko
 * IGME.201 - Practice Exercise #14
 * Console application features an interface and two class to inherit it, which will print a console statement by calling a method.
 * Still not entirely sure if my TryMethod() should just be MyMethod(), but I'm pretty sure I'm getting the intended effect.
 */
namespace PE14_Aluko
{


    /*
     * interface InhInterface functionality
     * defines interface method to be called in two classes
     */
    public interface InhInterface
    {
        void TryMethod(); //defined method - from Q2
    }

    /*
     * class OneClass functionality
     * inherits from interface
     * calls upon TryMethod() to print to console
     */
    public class OneClass : InhInterface
    {
        public void TryMethod()
        {
            Console.WriteLine("Class 1 text!");
        }
    }

    /*
     * class TwoClass functionality
     * inherits from interface
     * calls upon TryMethod() to print to console
     */
    public class TwoClass : InhInterface
    {
        public void TryMethod()
        {
            Console.WriteLine("Class 2 text??");
        }
    }

    /*
     * class Program functionality
     * --> main functionality
     * --- creates objects for classes one and two
     * --- calls upon MyMethod() for both classes
     * --> MyMethod() functionality
     * --- set parameters of new myObject
     * --- if statement checks if interface is myObject
     * --- if so, cast object to interface and call TryMethod() inside MyMethod()
     */
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            //class objects
            OneClass oneObject = new OneClass();
            TwoClass twoObject = new TwoClass();

            //call upon MyMethod for each class
            MyMethod(oneObject);
            MyMethod(twoObject);

        }

        public static void MyMethod(object myObject)
        {
            
            if (myObject is InhInterface)
            {
                InhInterface interfaceObject = (InhInterface)myObject;
                interfaceObject.TryMethod();
            }
        
        }

    }


}
