using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Unit Test #2
 * Converting a yuml diagram of my (green) tea drinking into a C# console application!
 */
namespace EX2_Aluko_Hobby
{
    

    /*
     * class Program functionality
     * Main()
     * --> initializes child class objects
     * --> MyMethod called w/ child class objects
     * MyMethod()
     * --> nested if-if/else loop checks if object is tea and uses boil or chill interface
     * --> will print console message depending on user choice
     */
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //new GreenTea and BlackTea class objects
            GreenTea greenTea = new GreenTea();
            BlackTea blackTea = new BlackTea();

            //MyMethod called w/ class objects
            MyMethod(greenTea);
            MyMethod(blackTea);
        }

        static void MyMethod(object obj)
        {
            if (obj is Tea tea) //object will always be tea
            {
                //prints console dialogue based on tea type
                Console.WriteLine("Preparing tea:");
                Console.WriteLine($"Flavor: {tea.FlavorMethod()}");
                Console.WriteLine($"Sweetening: {tea.SweetMethod()}");
                
                if (obj is iBoiled boiled) //boiled or...
                {
                    Console.WriteLine("Boiling tea...");
                    boiled.Boil();
                } else if (obj is iChilled chilled) //... chilled
                {
                    Console.WriteLine("Chilling tea...");
                    chilled.Chill();
                }

            }

        }

    }

    /*
     * abstract class tea functionality
     * initializes temp and time properties
     * initializes abstract flavor method as string
     * initializes virtual sweeten method as string
     * --> returns sweeten method as string
     */
    public abstract class Tea
    {
        
        //properties of tea
        public int temp { get; set; }
        public int time { get; set; }

        public abstract string FlavorMethod();

        public virtual string SweetMethod()
        {
            return "Sweeten tea w/ honey!";
        }

    }

    /*
     * class GreenTea inherits Tea functionality
     * overridden FlavorMethod() called
     * --> returns string to add green tea flavoring
     */
    public class GreenTea : Tea
    {
        public override string FlavorMethod()
        {
            return "Add green tea leaves and turmeric.";
        }
    }

    /*
     * class BlackTea inherits Tea functionality
     * overridden FlavorMethod() called
     * --> returns string to add black tea flavoring
     */
    public class BlackTea : Tea
    {
        public override string FlavorMethod()
        {
            return "Add black tea leaves.";
        }
    }

    /*
     * interface iBoiled functionality
     * n/a
     */
    public interface iBoiled
    {
        void Boil();
    }

    /*
     * interface iChilled functionality
     * n/a
     */
    public interface iChilled
    {
        void Chill();
    }


}
