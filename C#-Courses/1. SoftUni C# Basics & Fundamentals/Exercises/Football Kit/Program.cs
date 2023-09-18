using System;

namespace Football_Kit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tshirt = double.Parse(Console.ReadLine());
            double sumNeeded = double.Parse(Console.ReadLine());


            double shorts = tshirt * 0.75;
            double shocks = shorts * 0.2;
            double shoes = (tshirt + shorts) * 2;

            double total = shorts + shocks + shoes + tshirt;

            total = total - total * 0.15;

            if (total >= sumNeeded)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {total:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {(sumNeeded- total):f2} lv. more.");
            }
        }
    }
}
