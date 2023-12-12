using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;



/*
 * Tyler Aluko
 * IGME.201 - Extra Credit, Pet C#metery
 * For extra credit, timer functionality has been added.
 * This console application randomly indexes between dogs and cats, prompting users for information before allowing the animals to execute random actions.
 * 
 * Observed timer issues:
 * -> Timer will occasionally print the eviction statement on the same line as the user prompt.
 * -> Timer will occasionally not print the eviction notices after 20 seconds.
 */
namespace EC_PetCemetery_NET
{
    
    
    //cat and dog classes inherit
    public abstract class Pet
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Pet() { }

        public Pet(string name, int age)
        {
            this.Name = name; //>:(
            this.Age = age; //>:(
        }

        //to be overridden
        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();

    }


    //dog interface w/ dog actions
    public interface IDog
    {
        //void Eat();
        //void Play();
        void Bark();
        void NeedWalk();
        //void GotoVet();

        //extra credit addition
        void Evicted();
    }


    //cat interface w/ cat actions
    public interface ICat
    {
        //void Eat();
        //void Play();
        void Scratch();
        void Purr();
        
        //extra credit addition
        void Evicted();
    }


    //class holds dog interface actions
    public class Dog : Pet, IDog
    {

        public Dog(string name, int age, int license) : base(name, age)
        {
            License = license;
        }

        public int License { get; }

        public override void Eat()
        {
            Console.WriteLine($"{Name}: Yummy, I will eat anything!");
        }

        public override void Play()
        {
            Console.WriteLine($"{Name}: Throw the ball! Throw the ball!");
        }

        public void Bark()
        {
            Console.WriteLine($"{Name}: Woof woof!");
        }

        public void NeedWalk()
        {
            Console.WriteLine($"{Name}: Woof woof, I need to go out.");
        }

        public override void GotoVet()
        {
            Console.WriteLine($"{Name}: Whimper whimper, no vet!");
        }

        //extra credit addition
        public void Evicted()
        {
            Console.WriteLine($"{Name}: AWOOOOOOOOOOOOAHH! That's super cold!");
        }

        //extra credit addition
        public static void EvictCat(object source, ElapsedEventArgs e)
        {

            //attempt 1 - the nested if statements will never both be true ;-;
            /*
            if (Pets.petList.Count > 0 && Pets.petList[0] is Cat cat)
            {
                if (Pets.petList.Count > 0 && Pets.petList[0] is Dog dog)
                {
                    Console.WriteLine($"{dog.Name}: You will be a homeless furball, {cat.Name}");
                    cat.Evicted();
                    Pets.petList.RemoveAt(0);
                }
            }
            */

            //attempt 2 - closer... but dogs can still evict dogs
            /*
            if (Pets.petList.Count > 0)
            {
                Pet pet = Pets.petList[0];

                if (pet is Dog dog)
                {
                    Console.WriteLine($"{nameof(Dog)} {dog.Name}: You will be a homeless furball, {pet.Name}");
                    ((Cat)pet).Evicted(); //cast to Cat, call Evicted
                    Pets.petList.RemoveAt(0);
                }
            }
            */

            //attempt 3 - FINALLY, kinda working, this shall do...
            if (Pets.petList.Count >= 2) //more than two pets in the list
            {
                Pet pet = Pets.petList[0];

                if (pet is Dog dog)
                {
                    Pet otherPet = Pets.petList[1];

                    if (otherPet is Cat cat) //first other pet needs to be cat
                    {
                        Console.WriteLine($"{nameof(Dog)} {dog.Name}: You will be a homeless furball, {cat.Name}");
                        cat.Evicted();
                        Pets.petList.RemoveAt(0);
                        Pets.petList.RemoveAt(0); //remove both dog and cat
                    }
                }
            }

        }

    }


    //class holds cat interface actions
    public class Cat : Pet, ICat
    {

        public Cat(string name, int age) : base(name, age)
        {
        }

        public override void Eat()
        {
            Console.WriteLine($"{Name}: Yuck, I don't like that!");
        }

        public override void Play()
        {
            Console.WriteLine($"{Name}: Where's that mouse...");
        }

        public void Scratch()
        {
            Console.WriteLine($"{Name}: Hiss!");
        }

        public void Purr()
        {
            Console.WriteLine($"{Name}: purrrrrrrrrrrrrrrrrrrr...");
        }

        public override void GotoVet()
        {
            Console.WriteLine($"{Name}: Hiss! No vet!");
        }

        //extra credit addition
        public void Evicted()
        {
            Console.WriteLine($"{Name}: AAAAAAAAAAAAAAAAAAAAAAH! Help me, I don't like the cold!");
        }

        //extra credit addition
        public static void EvictDog(object source, ElapsedEventArgs e)
        { //now let's do the same for dog eviction...
            if (Pets.petList.Count >= 2)
            {
                Pet pet = Pets.petList[0];

                if (pet is Cat cat)
                {
                    Pet otherPet = Pets.petList[1];

                    if (otherPet is Dog dog)
                    {
                        Console.WriteLine($"{nameof(Cat)} {cat.Name}: Now you're just a stray, {dog.Name}");
                        dog.Evicted();
                        Pets.petList.RemoveAt(0);
                        Pets.petList.RemoveAt(0); //remove both the cat and dog
                    }
                }
            }
        }

    }


    /*
     * public class Pets - functionality
     * 
     * public static List declares static property petList to hold instances of Pet class
     * pet this -> get/set access class in array and retrieves/sets values
     * lambda returns number of elements in petList
     * adds pet object to end of petList
     * removes first occurence of specified Pet object in petList
     * rermove element at specified index from petList
     */
    public class Pets
    {

        //holds instances of pet class
        public static List<Pet> petList = new List<Pet>();

        //access instances of pet class
        public Pet this[int nPetEl]
        {

            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                if (nPetEl < petList.Count)
                {
                    petList[nPetEl] = value;
                }
                else
                {
                    petList.Add(value);
                }
            }

        }

        //lambda
        public int Count => petList.Count;

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }

        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }

    }


    /*
     * class Program - functionality
     * 
     * initializes pets + interfaces reference variables
     * new instance of pets list
     * initializes random number generation
     * extra credit, creates base timer for cat eviction
     * extra credit +1, creates timer for dog eviction
     * for loop iterates 50 times
     * -> if, per iteration, 10% of entering block
     * --> if RNG is 1, generate new random number (0 or 1) to determine dog or cat addition
     * -> else, choose random activities
     * --> if RNG other than 1, select random pet from petList
     * --> if selected pet is null, skip current iteration, continue to next
     * --> if pet is dog, switch statement for multiple dog actions
     * --> if pet is cat, switch statement for multiple cat actions
     */
    class Program
    {

        static void Main()
        {

            //pets/interfaces reference variables
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets(); //pets list

            Random rand = new Random(); //RNG

            //extra credit addition - dogs timer
            Timer dogTimer = new Timer(20000);
            dogTimer.Elapsed += new ElapsedEventHandler(Dog.EvictCat);
            dogTimer.Start();
            
            //extra credit addition - cats timer
            Timer catTimer = new Timer(20000);
            catTimer.Elapsed += new ElapsedEventHandler(Cat.EvictDog);
            catTimer.Start();

            //x50 for loop
            for (int i = 0; i < 50; i++)
            {

                if (rand.Next(1, 11) == 1) //random number between 1 and 10; if a 1
                {

                    //add dog or cat
                    if (rand.Next(0, 2) == 0) //50% dog or cat
                    { //add dog condition
                        Console.WriteLine("You bought a dog!");

                        Console.Write("Dog's Name => ");
                        string dogName = Console.ReadLine();

                        Console.Write("Age => ");
                        int dogAge = int.Parse(Console.ReadLine());

                        Console.Write("License => ");
                        int dogLicense = int.Parse(Console.ReadLine());

                        dog = new Dog(dogName, dogAge, dogLicense);
                        pets.Add(dog);
                    }
                    else
                    { //add cat condition
                        Console.WriteLine("You bought a cat!");

                        Console.Write("Cat's Name => ");
                        string catName = Console.ReadLine();

                        Console.Write("Age => ");
                        int catAge = int.Parse(Console.ReadLine());

                        cat = new Cat(catName, catAge);
                        pets.Add(cat);
                    }

                }
                else //choose random pet and activity
                {

                    thisPet = pets[rand.Next(0, pets.Count)];

                    if (thisPet == null)
                    {
                        continue;
                    }

                    if (thisPet is IDog)
                    { //random dog actions

                        iDog = (IDog)thisPet;
                        int action = rand.Next(0, 5);

                        switch (action)
                        {
                            case 0:
                                thisPet.Eat();
                                break;
                            case 1:
                                thisPet.Play();
                                break;
                            case 2:
                                iDog.Bark();
                                break;
                            case 3:
                                iDog.NeedWalk();
                                break;
                            case 4:
                                thisPet.GotoVet();
                                break;
                        }

                    }

                    else if (thisPet is ICat)
                    { //random cat actions

                        iCat = (ICat)thisPet;
                        int action = rand.Next(0, 5);

                        switch (action)
                        {
                            case 0:
                                thisPet.Eat();
                                break;
                            case 1:
                                thisPet.Play();
                                break;
                            case 2:
                                iCat.Purr();
                                break;
                            case 3:
                                iCat.Scratch();
                                break;
                            case 4:
                                thisPet.GotoVet();
                                break;
                        }

                    }

                }

            }

        }

    }


}
