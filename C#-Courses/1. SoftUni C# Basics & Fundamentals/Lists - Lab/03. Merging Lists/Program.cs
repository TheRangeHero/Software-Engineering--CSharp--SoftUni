using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = new List<int>();

            int longestList = Math.Max(listOne.Count, listTwo.Count);

            for (int i = 0; i <longestList; i++)
            {
                if (listOne.Count>i)
                {
                    result.Add(listOne[i]);
                }
                if (listTwo.Count>i)
                {
                    result.Add(listTwo[i]);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
