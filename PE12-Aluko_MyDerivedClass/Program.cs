using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Practice Exercise #12
 * My Derived Class
 * Console application contains different classes that will override a string to add some text output from the derived class.
 */
namespace PE12_Aluko_MyDerivedClass
{


    /*
     * Tyler Aluko
     * class MyClass - from Q1
     * defines public class myClass and public virtual method GetString()
     * returns private string myString
     */
    public class MyClass
    {

        private string myString;

        public virtual string GetString()
        {
            return myString = "know i'm the monster that u made"; //added some random text just to see if myString is carried
        }

    }


    /*
     * Tyler Aluko
     * class MyDerivedClass - derived from myClass
     * override GetString() method
     * return string from base class w/ appended text
     */
    public class MyDerivedClass : MyClass
    {
        
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }

    }


    /*
     * Tyler Aluko
     * class Program
     * instantiates MyDerivedClass object
     * outputs new returned GetString()
     */
    internal class Program
    {
        
        static void Main(string[] args)
        {
            MyDerivedClass derivedClass = new MyDerivedClass();
            Console.WriteLine(derivedClass.GetString());
        }

    }


}
