using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int[] evenArr = new int[input];
            int[] oddArr = new int[input];

            for (int i = 0; i < evenArr.Length; i++)
            {
                int[] currentInputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    evenArr[i] = currentInputs[0];
                    oddArr[i] = currentInputs[1];
                }
                else
                {
                    evenArr[i] = currentInputs[1];
                    oddArr[i] = currentInputs[0];
                }
            }
            Console.WriteLine(String.Join(' ', evenArr));
            Console.WriteLine(String.Join(' ', oddArr));
        }
    }
}
