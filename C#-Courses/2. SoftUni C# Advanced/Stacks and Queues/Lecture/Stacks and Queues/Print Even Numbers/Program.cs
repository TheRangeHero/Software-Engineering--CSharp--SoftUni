using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] expresion = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (var number in expresion)
            {
                if (number % 2 == 0)
                {
                    queue.Enqueue(number);
                }
            }

            Console.WriteLine($"{string.Join(", ", queue)}");

        }
    }
}
