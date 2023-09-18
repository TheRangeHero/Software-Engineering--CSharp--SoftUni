using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> occurencesByNumber = new SortedDictionary<double, int>();

            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (int number in numbers)
            {
                if (!occurencesByNumber.ContainsKey(number))
                {
                    occurencesByNumber.Add(number, 0);
                }

                occurencesByNumber[number]++;
            }

            foreach (var occurenceByNumber in occurencesByNumber)
            {
                Console.WriteLine($"{occurenceByNumber.Key} -> {occurenceByNumber.Value}");
            }
        }
    }
}
