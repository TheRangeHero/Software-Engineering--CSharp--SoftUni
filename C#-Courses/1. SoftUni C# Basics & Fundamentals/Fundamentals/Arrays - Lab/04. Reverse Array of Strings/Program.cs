using System;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length/2; i++)
            {
                string frontEment = input[i];
                input[i] = input[(input.Length - 1) - i];
                input[(input.Length - 1) - i] = frontEment;
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
