using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double income = 0.0;

            if (projection == "Premiere")
            {
                income = (row * colums) * 12;
            }

            else if (projection == "Normal")
            {
                income = (row * colums) * 7.50;
            }

            else if (projection == "Discount")
            {
                income = (row * colums) * 5.00;
            }

            Console.WriteLine($"{income:F2} leva");
        }
    }
}
