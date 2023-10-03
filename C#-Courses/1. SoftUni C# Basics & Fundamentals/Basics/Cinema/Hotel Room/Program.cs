using System;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceApp = 0.0;
            double priceStudio = 0.0;

            if (month == "May" || month == "October")
            {
                priceStudio = 50;
                priceApp = 65;
            }

            else if (month == "June" || month == "September")
            {
                priceStudio = 75.20;
                priceApp = 68.70;

            }

            else if (month == "July" || month == "August")
            {
                priceStudio = 76;
                priceApp = 77;            
            }
            
            if (nights > 14)
            {
                priceApp = priceApp - priceApp * 0.1;
                if (month == "May" || month == "October")
                {
                    priceStudio = priceStudio - priceStudio * 0.3;
                }

                else if (month == "June" || month == "September")
                {
                    priceStudio = priceStudio - priceStudio * 0.2;
                }
            }
           
            else if (nights > 7 && (month == "May" || month == "October"))
            {
                priceStudio = priceStudio - priceStudio * 0.05;
            }


            double totalCostApp = nights * priceApp;
            double totalCostStudio = nights * priceStudio;

            Console.WriteLine($"Apartment: {totalCostApp:f2} lv.");
            Console.WriteLine($"Studio: {totalCostStudio:f2} lv.");

        }
    }
}
