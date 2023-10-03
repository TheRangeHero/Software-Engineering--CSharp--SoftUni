using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string vacantionType = "";
            string destination = "";
            double moneySpend = 0.0;

            switch (season)
            {
                case "summer":
                    vacantionType = "Camp";
                    break;

                case "winter":
                    vacantionType = "hotel";
                    break;            
            }

            switch (budget)
            {
                case <= 100:
                    destination = "Bulgaria";
                    break;

                case <= 1000:
                    destination = "Balkans";
                    break;

                default:
                    destination = "Europe";
                    break;
            }

            if (destination == "Bulgaria")
            {
                if (vacantionType == "Camp")
                {
                    moneySpend = budget * 0.3;
                }
                else
                {
                    moneySpend = budget * 0.7;
                }
            }

            else if (destination == "Balkans")
            {
                if (vacantionType == "Camp")
                {
                    moneySpend = budget * 0.4;
                }
                else
                {
                    moneySpend = budget * 0.8;
                }
            }

            else
            {
                moneySpend = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{vacantionType} - {moneySpend:F2}");
        }
    }
}
