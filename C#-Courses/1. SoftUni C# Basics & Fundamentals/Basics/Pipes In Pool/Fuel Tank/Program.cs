using System;

namespace Fuel_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            

            if (liters >= 25 && (fuel == "Diesel" || fuel == "Gas" || fuel == "Gasoline"))
            {
                Console.WriteLine($"You have enough {fuel.ToLower()}.");
            }
            else if (liters<= 25 && (fuel == "Diesel" || fuel == "Gas" || fuel == "Gasoline"))
            {
                Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
            }
            else
            {
                Console.WriteLine($"Invalid fuel!");
            }
        }
    }
}
