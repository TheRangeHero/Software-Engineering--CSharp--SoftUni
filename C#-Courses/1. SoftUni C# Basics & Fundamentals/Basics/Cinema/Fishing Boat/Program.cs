using System;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int groupNumber = int.Parse(Console.ReadLine());

            double price = 0.0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;

                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;

                case "Winter":
                    price = 2600;
                    break;

            }

            if (groupNumber <= 6)
            {
                price = price - price * 0.10;
            }

            else if (groupNumber <= 11)
            {
                price = price - price * 0.15;
            }

            else
            {
                price = price - price * 0.25;
            }

            if (groupNumber % 2 == 0 && season != "Autumn")
            {
                price = price - price * 0.05;
            }

            double moneyLeft = budget - price;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
            }

            else
            {
                moneyLeft = Math.Abs(moneyLeft);
                Console.WriteLine($"Not enough money! You need {moneyLeft:f2} leva.");
            }
        }
    }
}
