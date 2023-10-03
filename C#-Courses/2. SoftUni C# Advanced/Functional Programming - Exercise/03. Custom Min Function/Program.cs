using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallestNumer = (number) =>
             {
                 int small = int.MaxValue;
                 for (int i = 0; i < number.Length; i++)
                 {
                     if (number[i]<small)
                     {
                         small = number[i];
                     }
                 }
                 return small;
             };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            Console.WriteLine(smallestNumer(numbers));
        }
    }
}
