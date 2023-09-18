using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int counter = 1;
            int longestCounter = 0;
            int elements = 0;


            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter > longestCounter)
                {
                    longestCounter = counter;
                    elements = numbers[i];
                }
            }
            for (int j =0 ; j < longestCounter; j++)
            {
                Console.Write($"{elements} ");
            }
        }
    }
}
