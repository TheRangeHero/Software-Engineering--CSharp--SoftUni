using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string vacantionType = "";
            string destination = "";
            double moneySpend = 0.0;
           

            if (budget <= 100)
            {
                destination = "Bulgaria";
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
            }
            else
            {
                destination = "Europe";
            }

            if (season == "winter" || destination == "Europe")
            {
                vacantionType = "Hotel";
            }
            else if (season == "summer" )
            {
                vacantionType = "Camp";
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
