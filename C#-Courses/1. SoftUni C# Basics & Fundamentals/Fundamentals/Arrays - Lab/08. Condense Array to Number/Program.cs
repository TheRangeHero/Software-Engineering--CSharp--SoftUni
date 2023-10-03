using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] condensed = new int[numers.Length - 1];


            while (numers.Length > 1)
            {


                for (int i = 0; i < numers.Length - 1; i++)
                {
                    condensed[i] = numers[i] + numers[i + 1];
                    if (i == numers.Length - 2)
                    {
                        numers = condensed;
                        condensed = new int[numers.Length - 1];
                    }
                }
            }
            Console.WriteLine(numers[0]);
        }
    }
}
