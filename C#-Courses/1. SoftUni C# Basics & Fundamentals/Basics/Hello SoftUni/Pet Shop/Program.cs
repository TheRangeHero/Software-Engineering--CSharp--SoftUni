using System;

namespace Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dog = int.Parse(Console.ReadLine());
            int cat = int.Parse(Console.ReadLine());

            double price = dog * 2.50 + cat * 4;

            Console.WriteLine($"{price} lv.");
        }
    }
}
