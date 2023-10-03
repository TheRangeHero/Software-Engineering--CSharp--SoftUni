using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;

            if (group == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 10.46;
                }
            }

            else if (group == "Business")
            { 
            if (dayOfWeek== "Friday")
                {
                    price = 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16;
                }
            }

            else if (group == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 22.50;
                }
            }

            double totalPrice = price * peopleCount;

            if (group == "Students" && peopleCount >= 30)
            {
                totalPrice = totalPrice - totalPrice * 0.15;
            }

           else if (group == "Business" && peopleCount >= 100)
            {
                totalPrice = totalPrice - price * 10;
            }

            else if (group == "Regular" && peopleCount >= 10 && peopleCount <= 20)
            {
                totalPrice = totalPrice - totalPrice * 0.05;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
