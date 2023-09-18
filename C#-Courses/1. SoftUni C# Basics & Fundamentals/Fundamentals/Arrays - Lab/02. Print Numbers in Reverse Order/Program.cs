using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] number = new int[n];

            for (int i = 0; i < number.Length; i++)
            {

                number[i] = int.Parse(Console.ReadLine());
            }

            for (int i = number.Length-1; i >=0; i--)
            {
                Console.Write($"{number[i]} ");
            }
        }
    }
}
