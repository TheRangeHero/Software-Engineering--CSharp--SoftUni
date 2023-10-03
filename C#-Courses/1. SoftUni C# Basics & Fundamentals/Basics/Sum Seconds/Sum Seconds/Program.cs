using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            int p3 = int.Parse(Console.ReadLine());

            int secondSum = p1 + p2 + p3;

            int minutes = secondSum / 60;
            int seconds = secondSum % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
