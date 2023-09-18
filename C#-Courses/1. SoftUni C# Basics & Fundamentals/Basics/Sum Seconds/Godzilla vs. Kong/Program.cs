using System;

namespace Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int screenwriters = int.Parse(Console.ReadLine());
            double costumes = double.Parse(Console.ReadLine());

            double decoration = budget * 0.1;
            double costumePrice = screenwriters * costumes;

            if (screenwriters > 150)
            {
                costumePrice = costumePrice - costumePrice * 0.1;
            }
            double Price = costumePrice + decoration;
            double difference = Price - budget;

            if (difference > 0)
            {
                
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {difference:F2} leva more.");
            }
            else
            {
                difference = Math.Abs(difference);
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {difference:F2} leva left.");
            }
        }
    }
}
