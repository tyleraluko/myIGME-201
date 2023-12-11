using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/*
 * Tyler Aluko
 * IGME.201 - Extra Credit, Recursion
 * Added a recursive method, SortArray to sort numbers entered by the user either in ascending or descending order.
 */
class Program
{
    // declare the delegate function type which will call either GetLowestArrayValue() or GetHighestArrayValue() depending on sSortDirection
    // note that the function signature must be the same for all functions it may represent
    // in this case both functions return a double and take a double[] as the parameter
    delegate double getArrayValueDelegate(double[] dArray);

    static double GetLowestArrayValue(double[] dArray)
    {
        // get the lowest value from dArray
        // returns double

        int arrayEl;

        double dLowestValue = dArray[0];

        // this function could use either for() or foreach()
        for (arrayEl = 0; arrayEl < dArray.Length; ++arrayEl)
        {
            if (dArray[arrayEl] < dLowestValue)
            {
                dLowestValue = dArray[arrayEl];
            }
        }

        return (dLowestValue);
    }

    static double GetHighestArrayValue(double[] dArray)
    {
        // get the highest value from dArray
        // returns double

        double dHighestValue = dArray[0];

        // this function could use for() or foreach()
        foreach (double thisValue in dArray)
        {
            if (thisValue > dHighestValue)
            {
                dHighestValue = thisValue;
            }
        }

        return (dHighestValue);
    }

    static void RemoveArrayValue(double dValue, ref double[] dArray)
    {
        // remove dValue from dArray
        // return value: dArray is changed by reference

        int srcEl;
        int destEl;

        // flag whether dValue was already removed
        bool dValueAlreadyRemoved = false;

        // create array with 1 less element
        double[] arrayMinusOne = new double[dArray.Length - 1];

        destEl = 0;

        // copy all elements from dArray into arrayMinusOne array except for the value we want to remove
        // NOTE THAT WE ONLY WANT TO REMOVE THE FIRST OCCURRENCE OF dValue 
        // (dValue could occur multiple times in dArray)
        for (srcEl = 0; srcEl < dArray.Length; ++srcEl)
        {
            // if this value equals the value to be removed
            // and we did not already remove it
            if (dArray[srcEl] == dValue && !dValueAlreadyRemoved)
            {
                // set the flag that we skipped the first instance of this dValue
                dValueAlreadyRemoved = true;
            }
            else
            {
                // otherwise add the unsorted array el to the newly sized array
                arrayMinusOne[destEl] = dArray[srcEl];

                // increment destEl only if a value was inserted into the new array
                ++destEl;
            }
        }

        // set dArray equal to the new array with dValue removed
        dArray = arrayMinusOne;
    }

    //recursive function sorts array
    static void SortArray(double[] unsortedArray, ref double[] sortedArray, getArrayValueDelegate getArrayValue, ref int nSortedLength)
    {
        //if unsorted array empty, return
        if (unsortedArray.Length == 0)
        {
            return;
        }

        double thisValue = getArrayValue(unsortedArray);

        //remove thisValue from unsorted array
        RemoveArrayValue(thisValue, ref unsortedArray);

        //increment the length of the sorted array
        ++nSortedLength;

        //resize the sorted array with the correct size
        Array.Resize(ref sortedArray, nSortedLength);

        //add thisValue to the end of sorted array
        sortedArray[nSortedLength - 1] = thisValue;

        //recursive call continues sorting remaining unsorted array
        SortArray(unsortedArray, ref sortedArray, getArrayValue, ref nSortedLength);
    }

    static void Main()
    {
        // Sort any number of entered decimal values in ascending or descending order

        // declare the delegate function variable
        getArrayValueDelegate getArrayValue;

        double[] aUnsorted;
        double[] aSorted;

        // counters for how many elements in each array
        int nUnsortedLength = 0;
        int nSortedLength = 0;

        string sSortDirection = null;

    start:

        // initialize our variables
        sSortDirection = null;
        nUnsortedLength = 0;

        Console.Write("Input any number of numbers separated by spaces -> ");
        string sList = Console.ReadLine();

        string[] sNumbers = sList.Split(' ');

        // allocate our unsorted array based on how many numbers were entered
        aUnsorted = new double[sNumbers.Length];

        foreach (string sNumber in sNumbers)
        {
            // if this word is an empty string (because they entered more than 1 space in a row)
            if (sNumber.Length == 0)
            {
                continue;
            }

            try
            {
                // try to convert this number to a double
                aUnsorted[nUnsortedLength] = Convert.ToDouble(sNumber);
            }
            catch (Exception e)
            {
                // catch the exception if the conversion was not successful (eg. due to non-numeric characters in the string)
                Console.WriteLine();
                Console.WriteLine(e.Message);

                // output the first invalid digit
                Console.WriteLine("Invalid digit at position " + (nUnsortedLength + 1));
                Console.WriteLine();

                // loop back to request a new string of numbers
                goto start;
            }
            // finally is optional and ALWAYS executed whether or not an exception occurred
            //finally
            //{
            //    Console.WriteLine($"{nUnsortedLength + 1}: finally!");
            //}

            ++nUnsortedLength;
        }

        // check to ensure that nUnsortedLength == aUnsorted.Length
        // they will not be equal if any double spaces were entered in the input string
        if (nUnsortedLength != aUnsorted.Length)
        {
            double[] correctSizedArray = new double[nUnsortedLength];

            // copy the first nUnsortedLength elements into the correct sized array
            for (int arrayEl = 0; arrayEl < nUnsortedLength; ++arrayEl)
            {
                correctSizedArray[arrayEl] = aUnsorted[arrayEl];
            }

            // set aUnsorted to the correctSizedArray
            aUnsorted = correctSizedArray;
        }

        // allocate our array to hold the sorted values with the correct size
        aSorted = new double[aUnsorted.Length];

        do
        {
            Console.Write("Sort in Ascending or Descending Order: ");
            sSortDirection = Console.ReadLine();
            sSortDirection = sSortDirection.ToLower();
        } while (!(sSortDirection.Contains("asc") || sSortDirection.Contains("des"))); //changed && to ||, wasn't accepting correct answers

        // start with 0 elements in the result array
        nSortedLength = 0;

        if (sSortDirection.Contains("asc"))
        {
            // if we are to sort in ascending order
            // initialize the delegate function to use GetLowestArrayValue()
            getArrayValue = new getArrayValueDelegate(GetLowestArrayValue);
        }
        else
        {
            // otherwise sorting in descending order
            // initialize the delegate function to use GetHighestArrayValue()
            getArrayValue = new getArrayValueDelegate(GetHighestArrayValue);
        }

        //call recursive function to sort array
        SortArray(aUnsorted, ref aSorted, getArrayValue, ref nSortedLength);

        // write out the sorted array
        for (int i = 0; i < nSortedLength; ++i)
        {
            Console.Write(aSorted[i] + " ");
        }

        Console.WriteLine();
    }
}