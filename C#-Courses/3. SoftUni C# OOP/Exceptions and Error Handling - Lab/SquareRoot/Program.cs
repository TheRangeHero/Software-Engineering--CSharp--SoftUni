using System;
using System.Reflection.Metadata.Ecma335;

namespace SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new FormatException("Invalid number.");

                }
                int squareRoot = (int)Math.Sqrt(number);
                Console.WriteLine(squareRoot);

            }
            catch (FormatException fex)
            {

                Console.WriteLine(fex.Message);

            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
