using System;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<int> intList = new Box<int>();
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());

                intList.ListOfInt.Add(input);
            }

            int[] positionsToSwap = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            intList.SwapIntMethod(positionsToSwap[0], positionsToSwap[1]);

            Console.WriteLine(intList.ToString());
        }
    }
}
