using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> reversedArr = arr =>
             {
                 List<int> result = new List<int>();
                 for (int i = arr.Count - 1; i >= 0; i--)
                 {
                     result.Add(arr[i]);
                 }
                 return result;
             };

            Func<List<int>, Predicate<int>, List<int>> excludeDIvisible = (numbers, match) =>
              {
                  List<int> result = new List<int>();

                  foreach (var number in numbers)
                  {

                      if (!match(number))
                      {
                          result.Add(number);
                      }
                  }
                  return result;
              };


            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            int divisibleParameter = int.Parse(Console.ReadLine());

            numbers = excludeDIvisible(numbers, n => n % divisibleParameter == 0);

            numbers = reversedArr(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
