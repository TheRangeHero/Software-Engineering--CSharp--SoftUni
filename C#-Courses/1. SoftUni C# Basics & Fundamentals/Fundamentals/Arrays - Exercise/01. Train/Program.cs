using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());

            int[] wagons = new int[numberOfWagons];
            int sum = 0;
            for (int i = 0; i < wagons.Length; i++)
            {


                wagons[i] = int.Parse(Console.ReadLine());
                sum += wagons[i];
            }
            foreach (int wagon in wagons)
            {
                Console.Write($"{wagon} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
