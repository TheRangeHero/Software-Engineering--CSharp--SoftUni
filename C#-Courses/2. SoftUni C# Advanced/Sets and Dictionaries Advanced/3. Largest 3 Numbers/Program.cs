using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            numbers = numbers.OrderByDescending(x => x).Take(3).ToList();

            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}
