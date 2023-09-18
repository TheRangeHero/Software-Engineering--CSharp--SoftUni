using System;

namespace Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int charSum = 0;
            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());
                charSum += input;
            }
            Console.WriteLine($"The sum equals: {charSum}");
        }
    }
}
