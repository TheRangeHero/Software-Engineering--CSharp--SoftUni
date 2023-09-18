using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());


            for (int i = 1; i <= input; i++)
            {
                if (SumOfAllDigits(i) && OddDigitChecker(i))
                {
                    Console.WriteLine(i);
                }
            }            
        }


        static bool SumOfAllDigits(int number)
        {
            int result = 0;

            while (number > 0)
            {
                result += number % 10;
                number /= 10;
            }

            if (result % 8 == 0)
            {
                return true;
            }            
                return false;
           
        }


        static bool OddDigitChecker(int number)
        {
            int result = 0;
            while (number > 0)
            {
                result = number % 10;
                if (result%2!=0)
                {
                    return true;
                }

                number /= 10;
            }

            return false;
        }
    }
}
