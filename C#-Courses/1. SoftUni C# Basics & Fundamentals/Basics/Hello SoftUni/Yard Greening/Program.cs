using System;

namespace Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());

            //double startprice = meters * 7.61; 
            double discount = (meters * 7.61) * 0.18;
            double price = (meters * 7.61) - discount;
            Console.WriteLine($"The final price is: {price} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
