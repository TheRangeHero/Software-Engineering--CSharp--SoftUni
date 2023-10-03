using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            int nInputCount = inputs[0];
            int mInputCount = inputs[1];

            HashSet<int> nInputs = new HashSet<int>();
            HashSet<int> mInputs = new HashSet<int>();


            for (int i = 0; i < nInputCount; i++)
            {
                nInputs.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < mInputCount; i++)
            {
                mInputs.Add(int.Parse(Console.ReadLine()));
            }


            nInputs.IntersectWith(mInputs);

            if (nInputs.Any())
            {
                Console.WriteLine(String.Join(' ', nInputs));
            }

        }
    }
}
