using System;

namespace Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingCharIndex = int.Parse(Console.ReadLine());
            int endingCharIndex = int.Parse(Console.ReadLine());

            for (int i = startingCharIndex; i <= endingCharIndex; i++)
            {
                Console.Write($"{(char)i} ");
            }

        }
    }
}
