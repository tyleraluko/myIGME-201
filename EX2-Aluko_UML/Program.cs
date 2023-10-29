using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2_Aluko_UML
{

    static void Main(string[] args)
    {
        //...
    }

    //+Tardis
    public class Tardis
    {
        
        private bool sonicScrewdriver; //-sonicScrewdriver:bool
        private byte whichDrWho; //-whichDrWho:byte
        private string femaleSideKick; //-femaleSideKick:string

        
        public bool SonicScrewdriver
        {
            get { return sonicScrewdriver; }
        }

        //+WhichDrWho:byte:r
        public byte WhichDrWho
        {
            get { return whichDrWho; }
        }

        //+FemaleSideKick:string:r
        public string FemaleSideKick
        {
            get { return femaleSideKick; }
        }


        public double ExteriorSurfaceArea { get; set; } //+exteriorSurfaceArea:double
        public double InteriorVolume { get; set; } //+interiorVolume:double


        //public byte WhichDrWho { get; } //+WhichDrWho:byte:r


        //public string FemaleSideKick { get; } //+FemaleSideKick:string:r

        //+TimeTravel()
        public void TimeTravel()
        {
            //...
        }

        public static bool operator ==(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == 10 && t2.whichDrWho != 10)
            {
                return true;
            }
            else if (t1.whichDrWho != 10 && t2.whichDrWho == 10)
            {
                return false;
            }
            else
            {
                return t1.whichDrWho == t2.whichDrWho;
            }
        }

        public static bool operator !=(Tardis t1, Tardis t2)
        {
            return !(t1 == t2);
        }

        public static bool operator <(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == 10 && t2.whichDrWho != 10)
            {
                return false;
            }
            else if (t1.whichDrWho != 10 && t2.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return t1.whichDrWho < t2.whichDrWho;
            }
        }

        public static bool operator >(Tardis t1, Tardis t2)
        {
            if (t1.whichDrWho == 10 && t2.whichDrWho != 10)
            {
                return true;
            }
            else if (t1.whichDrWho != 10 && t2.whichDrWho == 10)
            {
                return false;
            }
            else
            {
                return t1.whichDrWho > t2.whichDrWho;
            }
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
    public interface IPhoneInterface
    {
        void Answer(); //Answer()
        void MakeCall(); //MakeCall()
        void HangUp(); //HangUp()
    }

    //+PhoneBooth
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
