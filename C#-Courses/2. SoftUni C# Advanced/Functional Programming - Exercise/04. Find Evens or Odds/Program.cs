using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {

            Predicate<int> even = number => number % 2 == 0;
            Predicate<int> odd = number => number % 2 != 0;

            int[] ranges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            List<int> numbers = new List<int>();
            List<int> result = new List<int>();
            for (int i = ranges[0]; i <= ranges[1]; i++)
            {
                numbers.Add(i);
            }

            bool isEven = Console.ReadLine() == "even";

            if (isEven)
            {
                result = numbers.FindAll(even);
            }
            else
            {
                result = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
