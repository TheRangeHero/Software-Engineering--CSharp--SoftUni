using System;

namespace Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double pricePerPeople = 0;

            switch (season)
            {
                case "spring":
                    if (peopleCount <= 5)
                    {
                        pricePerPeople = 50.00;
                    }
                    else
                    {
                        pricePerPeople = 48.00;
                    }
                    break;
                case "summer":
                    if (peopleCount <= 5)
                    {
                        pricePerPeople = 48.50;
                    }
                    else
                    {
                        pricePerPeople = 45.00;
                    }
                    break;
                case "autumn":
                    if (peopleCount <= 5)
                    {
                        pricePerPeople = 60.00;
                    }
                    else
                    {
                        pricePerPeople = 49.50;
                    }
                    break;
                case "winter":
                    if (peopleCount <= 5)
                    {
                        pricePerPeople = 86.00;
                    }
                    else
                    {
                        pricePerPeople = 85.00;
                    }
                    break;
            }

            double totalSum = peopleCount * pricePerPeople;

            if (season == "summer")
            {
                totalSum = totalSum - totalSum * 0.15;
            }
            else if (season == "winter")
            {
                totalSum = totalSum + totalSum * 0.08;
            }

            Console.WriteLine($"{totalSum:f2} leva.");
        }
    }
}
