using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(input);

            for (int i = 0; i <input; i++)
            {
                products.Add(Console.ReadLine());

            }
            products.Sort();

            int counter = 1;

            foreach (string product in products)
            {
                Console.WriteLine($"{counter}.{product}");
                counter++;
            }

        }
    }
}
