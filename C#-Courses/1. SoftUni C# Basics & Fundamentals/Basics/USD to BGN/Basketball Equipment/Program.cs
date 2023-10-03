using System;

namespace Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int taxes = int.Parse(Console.ReadLine());

            double shoes = taxes - (taxes * 40 / 100);
            double clothes = shoes - (shoes * 20 / 100);
            double ball = clothes * 1 / 4;
            double accessories = ball * 1 / 5;
            double price = taxes + shoes + clothes + ball + accessories;
            Console.WriteLine(price);
        }
    }
}
