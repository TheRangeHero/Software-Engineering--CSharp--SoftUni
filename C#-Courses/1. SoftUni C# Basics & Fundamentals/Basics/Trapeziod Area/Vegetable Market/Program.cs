using System;

namespace Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double Vegetables = double.Parse(Console.ReadLine());
            double fruits = double.Parse(Console.ReadLine());
            int kgVegs = int.Parse(Console.ReadLine());
            int kgFruits = int.Parse(Console.ReadLine());

            double SumLv = (Vegetables * kgVegs) + (fruits * kgFruits);
            double SumEuro = SumLv / 1.94;

            Console.WriteLine($"{SumEuro:f2}");
        }
    }
}
