using System;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] numbersAsString = input.Split(' ');
            //string[] numberAsString = Console.ReadLine().Split();

            double[] realNumbers = new double[numbersAsString.Length];

            for (int i = 0; i < numbersAsString.Length; i++)
            {
                realNumbers[i] = double.Parse(numbersAsString[i]);
            }

            for (int i = 0; i < realNumbers.Length; i++)
            {
                Console.WriteLine($"{realNumbers[i]} => {(int)Math.Round(realNumbers[i],MidpointRounding.AwayFromZero)}");
            }


        }
    }
}
