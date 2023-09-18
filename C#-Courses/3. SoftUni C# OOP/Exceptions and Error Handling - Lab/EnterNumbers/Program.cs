using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int[] numbers = new int[10];
            

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {

                    numbers[i] = ReadNumber(start, end);
                    if (numbers[i] <= start || numbers[i] > 100)
                    {
                        throw new ArgumentException($"Your number is not in range {start} - {end}!");
                    }



                }
                catch (FormatException fe)
                {

                    Console.WriteLine(fe.Message);
                    i--;
                    continue;
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                    i--;
                    continue;
                }

                start = numbers[i];

            }
            Console.WriteLine(string.Join(", ", numbers));


        }

        static int ReadNumber(int start, int end)
        {
            int number;

            string input = Console.ReadLine();
            while (!int.TryParse(input, out number))
            {
                throw new FormatException("Invalid Number!");
            }
            return number;
        }
    }
}
