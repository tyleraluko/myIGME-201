using System;
using System.Collections.Generic;
using System.Timers;



/*
 * Tyler Aluko
 * IGME.201 - Extra Credit, Pet C#metery
 * For extra credit, timer functionality has been added.
 * This console application randomly indexes between dogs and cats, prompting users for information before allowing the animals to execute random actions.
 * so many nulllllllllllllllllllllllllllll.......................
 */
namespace PE13_Aluko
{

    //cat and dog classes inherit
    public abstract class Pet
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Pet()
        {
        }

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
    }

    //cat interface w/ cat actions
    public interface ICat
    {
        //void Eat();
        //void Play();
        void Scratch();
        void Purr();
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

        //evicted
        public void Evicted()
        {
            Console.WriteLine($"{Name}: AAAAAAAAAAAAAAAAAAAAAAH! Help me, I don't like the cold!");
        }

    }

    //...
    public class Pets
    {

        public List<Pet> petList = new List<Pet>();

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

    //...
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