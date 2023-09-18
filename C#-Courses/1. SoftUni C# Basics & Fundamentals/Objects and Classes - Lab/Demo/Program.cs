using System;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog jhon = new Dog();
            jhon.Name = "Jhon";
            jhon.Breed = "pudel";
            jhon.Age = 6;
            jhon.Weight = 12.4;

            Dog maria = new Dog();
            maria.Name = "Maria";
            maria.Breed = "JR";
            maria.Age = 2;
            maria.Weight = 5.4;

            Console.WriteLine($"Name: {jhon.Name}, Age: {jhon.Age}.");
            Console.WriteLine(jhon.Bark());
            Console.WriteLine($"Name: {maria.Name}, Age: {maria.Age}.");
            Console.WriteLine(maria.Bark());

            Dog pesho = new Dog
            {
                Name = "Pesho",
                Age = 6,
                Breed = "Corgi",
                Weight = 4.5
            };

            Dog Sasho = pesho;
            Sasho.SashoSayName();

        }
    }

    public class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }

        public string Bark()
        {
            return "Bau!!";
        }

        public void SashoSayName()
        {
            Console.WriteLine($"{this.Name}, age {this.Age}, weight {this.Weight}");
        }
    }
}
