using System;

namespace Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int summ = 0;

            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");

                summ += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {summ}");
        }
    }
}
