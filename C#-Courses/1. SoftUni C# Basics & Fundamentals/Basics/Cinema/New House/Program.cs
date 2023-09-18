using System;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0.0;

             if (flowers == "Roses")
            {
                price = flowerCount * 5;
                if (flowerCount > 80)
                {
                    price = price - price * 0.10;
                }
            }

            else if (flowers == "Dahlias")
            {
                price = flowerCount * 3.80;
                if (flowerCount > 90)
                {
                    price = price - price * 0.15;
                }
            }

            else if (flowers == "Tulips")
            {
                price = flowerCount * 2.80;
                if (flowerCount > 80)
                {
                    price = price - price * 0.15;
                }
            }

            else if (flowers == "Narcissus")
            {
                price = flowerCount * 3;
                if (flowerCount < 120)
                {
                    price = price + price * 0.15;
                }
            }

            else if (flowers == "Gladiolus")
            {
                price = flowerCount * 2.50;
                if (flowerCount < 80)
                {
                    price = price + price * 0.20;
                }
            }

            double moneyLeft = budget - price;
            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowers} and {moneyLeft:F2} leva left.");
            }

            else
            {
                moneyLeft = Math.Abs(moneyLeft);
                Console.WriteLine($"Not enough money, you need {moneyLeft:F2} leva more.");
            }
            
            
        }
    }
}
