using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int piecesCount = width * lenght;
            bool isPieaceLeft = true;

            while (input != "STOP")
            {
                piecesCount -= int.Parse(input);
                if (piecesCount < 0)
                {
                    isPieaceLeft = false;
                    break;
                }
                input = Console.ReadLine();
            }

            if (isPieaceLeft != true)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(piecesCount)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{piecesCount} pieces are left.");
            }
        }
    }
}
