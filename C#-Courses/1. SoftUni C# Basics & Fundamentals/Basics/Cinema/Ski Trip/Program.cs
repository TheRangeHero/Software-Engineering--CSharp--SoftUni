using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int continuance = int.Parse(Console.ReadLine());
            string permises = Console.ReadLine();
            string rating = Console.ReadLine();

            double price = 0.0;


            if (permises == "apartment")
            {
                price = (continuance * 25) - 25;
            }

            else if (permises == "president apartment")
            {
                price = (continuance * 35) - 35;
            }

            else if (permises == "room for one person")
            {
                price = (continuance * 18) - 18;
            }

            if (continuance < 10)
            {
                if (permises == "apartment")
                {
                    price = price - price * 0.3;
                }

                else if (permises == "president apartment")
                {
                    price = price - price * 0.1;
                }
            }

            else if (continuance >= 10 && continuance <= 15)
            {
                if (permises == "apartment")
                {
                    price = price - price * 0.35;
                }

                else if (permises == "president apartment")
                {
                    price = price - price * 0.15;
                }
            }

            else if (continuance > 15)
            {
                if (permises == "apartment")
                {
                    price = price - price * 0.5;
                }

                else if (permises == "president apartment")
                {
                    price = price - price * 0.2;
                }
            }

            if (rating == "positive")
            {
                price = price  + price * 0.25;
            }

            else if (rating == "negative")
            {
                price = price - (price * 0.1);
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}
