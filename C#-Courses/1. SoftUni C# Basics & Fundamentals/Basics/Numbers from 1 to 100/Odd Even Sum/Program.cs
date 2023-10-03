using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSumm = 0;

            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += numbers;
                }
                else
                {
                    oddSumm += numbers;
                }

            }
            
            if (evenSum == oddSumm)
            {
                Console.Write($"Yes\nSum = {evenSum}");
            }

            else
            {
                int difference = evenSum - oddSumm;
                if (difference < 0)
                {
                    Console.WriteLine($"No\nDiff = {Math.Abs(difference)}");
                }
                else
                {
                    Console.WriteLine($"No\nDiff = {difference}");
                }
            }
        }
    }
}
