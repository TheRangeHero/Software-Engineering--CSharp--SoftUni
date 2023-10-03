using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumEven = 0;
            int sumOdd = 0;

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sumEven += number;
                }
                else if (number % 2 != 0)
                {
                    sumOdd += number;
                }
            }
            
            Console.WriteLine(sumEven-sumOdd);
        }
    }
}
