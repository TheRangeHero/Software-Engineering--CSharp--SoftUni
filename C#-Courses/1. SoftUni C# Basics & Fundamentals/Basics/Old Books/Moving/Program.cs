using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int totalSpace = width * lenght * height;
            bool isSpaceAvailable = true;

            while (input != "Done")
            {
                totalSpace -= int.Parse(input);

                if (totalSpace < 0)
                {
                    isSpaceAvailable = false;
                    break;
                }
                input = Console.ReadLine();
            }

            if (isSpaceAvailable == false)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(totalSpace)} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{totalSpace} Cubic meters left.");
            }
        }
    }
}
