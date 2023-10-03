using System;
using System.Linq;

namespace GenericSwapMethodString
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<string> stringSwap = new Box<string>();
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                stringSwap.StringList.Add(input);
            }

            int[] swapIndex = Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            stringSwap.SwapMethod(swapIndex[0], swapIndex[1]);

            Console.WriteLine(stringSwap.ToString());
        }
    }
}
