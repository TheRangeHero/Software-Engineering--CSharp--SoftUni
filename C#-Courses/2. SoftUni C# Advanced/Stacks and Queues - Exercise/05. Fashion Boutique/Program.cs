using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stackOfClothes = new Stack<int>(clothesNumber);
            int capacity = int.Parse(Console.ReadLine());
            int racksCount = 1;
            int rackInUse = capacity;
            while (stackOfClothes.Count>0)
            {
                if (stackOfClothes.Peek()<= rackInUse)
                {
                    rackInUse -= stackOfClothes.Pop();
                }
                else
                {
                    rackInUse = capacity;
                    racksCount++;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
