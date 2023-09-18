using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersAsString = Console.ReadLine().Split('|').Reverse().ToList();

            List<int> numbers = new List<int>();

            foreach (string num in numbersAsString)
            {
                numbers.AddRange(num.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}