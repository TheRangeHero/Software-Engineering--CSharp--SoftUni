using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            for (int i = 1; i<=height; i++)
            {
                PrintingLine(1, i);
            }

            for (int i = height-1; i >=1; i--)
            {
                PrintingLine(1, i);
            }
        }

        static void PrintingLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}
