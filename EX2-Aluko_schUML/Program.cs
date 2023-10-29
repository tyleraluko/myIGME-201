using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Tyler Aluko
 * IGME.201 - Unit Test #2
 * Questions 4-7.
 * Converts a schUML diagram of a Tardis to C# code.
 * !!
 * not exactly sure if i need to be putting things to test into all of these functions, will come back to test...
 */
namespace EX2_Aluko_schUML
{
    
    /*
     * class Program functionality
     * Main()
     * --> creates new objects for Tardis, RotaryPhone, PhoneBooth, and PushButtonPhone
     * --> calls upon UsePhone() method w/ class objects as arguments
     * UsePhone
     * --> objects as arguments
     * --> if/else loop checks which object is used and executes the corresponding task
     * ----> prints error message if object used is invalid
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //new class objects
            Tardis myTardis = new Tardis();
            RotaryPhone myRotaryPhone = new RotaryPhone();
            PhoneBooth myPhoneBooth = new PhoneBooth();
            PushButtonPhone myPushButtonPhone = new PushButtonPhone();

            //UsePhone method called w/ class objects as arguments
            UsePhone(myPushButtonPhone);
            UsePhone(myTardis);
            UsePhone(myPhoneBooth);

        }

        static void UsePhone(object obj)
        {
            if (obj is IPhoneInterface)
            {
                IPhoneInterface phone = (IPhoneInterface)obj;
                phone.MakeCall();
                phone.HangUp();
            }
            else if (obj is PhoneBooth)
            {
                PhoneBooth phoneBooth = (PhoneBooth)obj;
                phoneBooth.OpenDoor();
            }
            else if (obj is Tardis)
            {
                Tardis tardis = (Tardis)obj;
                tardis.TimeTravel();
            }
            else
            {
                Console.WriteLine("Invalid object.");
            }
        }
    }

    //+Tardis
    //these warnings are throwing me for a bit of a loop. programe doesn't crash, but will return to address as many of these as possible
    /*
     * class Tardis functionality
     * initializes and returns values for sonicScrewdriver, whichDrWho, and femaleSideKick
     * contains TimeTravel() function
     * should override, but doesn't yet...
     */
    public class Tardis
    {
        private bool sonicScrewdriver; //-sonicScrewdriver:bool
        private byte whichDrWho; //-whichDrWho:byte
        private string femaleSideKick; //-femaleSideKick:string

        public bool SonicScrewdriver
        {
            get { return sonicScrewdriver; }
        }

        public byte WhichDrWho
        {
            get { return whichDrWho; }
        }

        public string FemaleSideKick
        {
            get { return femaleSideKick; }
        }

        public double ExteriorSurfaceArea { get; set; } //+exteriorSurfaceArea:double
        public double InteriorVolume { get; set; } //+interiorVolume:double

        //+TimeTravel()
        public void TimeTravel()
        {
            //...
        }

        public static bool operator ==(Tardis t1, Tardis t2)
        {
            return t1.whichDrWho == t2.whichDrWho;
        }

        public static bool operator !=(Tardis t1, Tardis t2)
        {
            return !(t1 == t2);
        }

        public static bool operator <(Tardis t1, Tardis t2)
        {
            return t1.whichDrWho < t2.whichDrWho;
        }

        public static bool operator >(Tardis t1, Tardis t2)
        {
            return t1.whichDrWho > t2.whichDrWho;
        }

        public static bool operator <=(Tardis t1, Tardis t2)
        {
            return t1 < t2 || t1 == t2;
        }

        public static bool operator >=(Tardis t1, Tardis t2)
        {
            return t1 > t2 || t1 == t2;
        }
    }


    //+RotaryPhone
    /*
     * class RotaryPhone functionality
     * initializes and returns values for phoneNumber and address
     * --> phone number value not assigned yet...
     * contains Answer() function
     * contains MakeCall() function
     * contains HangUp() function
     */
    public class RotaryPhone
    {

        private string phoneNumber; //-phoneNumber:string
        public string address; //+address:string

        //+PhoneNumber:string
        public string PhoneNumber
        {
            get { return phoneNumber; }
        }


        public string Address
        {
            get { return address; }
        }

        //Answer()
        public void Answer()
        {
            //...
        }

        //MakeCall()
        public void MakeCall()
        {
            //...
        }

        //HangUp()
        public void HangUp()
        {
            //...
        }
    }

    //+I:PhoneInterface
    /*
     * interface IPhoneInterface functionality
     * to be inherited by PushButtonPhone
     */
    public interface IPhoneInterface
    {
        void Answer(); //Answer()
        void MakeCall(); //MakeCall()
        void HangUp(); //HangUp()
    }

    //+PhoneBooth
    /*
     * class PhoneBooth functionality
     * contains OpenDoor() and CloseDoor() functions
     */
    public class PhoneBooth
    {

        private bool superMan; //-superMan:bool
        public double CostPerCall { get; set; } //+costPerCall:double
        public bool PhoneBook { get; set; } //+PhoneBook:bool

        //OpenDoor()
        public void OpenDoor()
        {
            //...
        }

        //CloseDoor()
        public void CloseDoor()
        {
            //...
        }

    }

    //+PushButtonPhone --(inherit)--> +I:PhoneInterface
    /*
     * class PushButtonPhone inherits IPhoneInterface functionality
     * inherits IPhoneInterface and its functions
     */
    public class PushButtonPhone : IPhoneInterface
    {
        //+Answer()
        public void Answer()
        {
            //...
        }

        //+MakeCall()
        public void MakeCall()
        {
            //...
        }

        //+HangUp()
        public void HangUp()
        {
            //...
        }

    }


}
