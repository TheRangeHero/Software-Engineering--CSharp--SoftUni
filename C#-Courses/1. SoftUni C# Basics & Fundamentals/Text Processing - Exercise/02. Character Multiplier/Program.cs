using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split();
            
            Console.WriteLine(CharMultiplier(input[0], input[1]));
        }


        public static int CharMultiplier(string one, string two)
        {
            int sum = 0;

            string longest = string.Empty;
            string shortest = string.Empty;

            if (one.Length >two.Length)
            {
                longest = one;
                shortest = two;
            }
            else
            {
                longest = two;
                shortest = one;
            }


            for (int i = 0; i < shortest.Length; i++)
            {
                sum += one[i] * two[i];
            }

            for (int i = shortest.Length; i < longest.Length; i++)
            {
                sum += longest[i];
            }
            return sum;
        }
    }
}
