using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            input = Math.Abs(input);

            int evenSum = GetSumOfEvenNumbers(input);
            int oddSum = GetSumOfOddNumbers(input);
            int result = GetMultipleofEvenAndOdds(evenSum, oddSum);

            Console.WriteLine(result);
        }

        static int GetSumOfEvenNumbers(int input)
        {
            int sum = 0;
            int digits = input;

            while (digits>0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }
                digits = digits / 10;
            }

            return sum;
        }

        static int GetSumOfOddNumbers(int input)
        {
            int sum = 0;
            int digits = input;

            while (digits > 0)
            {
                int currentDigit = digits % 10;
                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }
                digits = digits / 10;
            }

            return sum;
        }

        static int GetMultipleofEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }
}
