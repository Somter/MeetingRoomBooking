using System.Xml.Linq;

namespace BankingConsoleApp
{

    class Person
    {
        public string name = "Undefined";
        public int age;

        public Person ()
        {
            Console.WriteLine("Creating Person object");
            name = "Tom";
            age = 98;
        }

         public void Print()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }

    class Cimpany
    {
        string title =
    }
    class Program
    {
        static void Main()
        {
            //Person person = new Person();

            //string newName = person.name;
            //int age = person.age;
            //Console.WriteLine($"New name: {person.name} age: {person.age}");
            //person.name = "Tom";
            //person.age = 120;
            //person.Print();

            //Person tom = new Person();
            //Person Saha = new Person("Sasha", 21);
            //Person Elon = new Person("Elon");

            //tom.Print();
            //Saha.Print();
            //Elon.Print();



        }
    }
}