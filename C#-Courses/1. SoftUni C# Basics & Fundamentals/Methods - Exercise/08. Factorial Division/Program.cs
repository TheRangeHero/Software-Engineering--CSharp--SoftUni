using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());

            double result1 = Factorel(numOne);
            double result2 = Factorel(numTwo);

            PrintResult(result1, result2);

        }


        private static double Factorel(int number)
        {
            double result = 1;
            while (number!=1)
            {
                result *= number;
                number--;
            }

            return result;
        }

        private static void PrintResult(double result1, double result2) =>
            Console.WriteLine($"{(result1 / result2):f2}");
        
        
    }
}
