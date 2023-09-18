using System;

namespace Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int maxNum = int.MinValue;
            string currentBest = "";


            while (name != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if (goals > maxNum)
                {
                    maxNum = goals;
                    currentBest = name;
                }
                if (goals >= 10)
                {
                    break;
                }
                name = Console.ReadLine();
            }

            Console.WriteLine($"{currentBest} is the best player!");
            if (maxNum >= 3)
            {
                Console.WriteLine($"He has scored {maxNum} goals and made a hat-trick !!!");
            }
            else
                Console.WriteLine($"He has scored {maxNum} goals.");
        }
    }
}
