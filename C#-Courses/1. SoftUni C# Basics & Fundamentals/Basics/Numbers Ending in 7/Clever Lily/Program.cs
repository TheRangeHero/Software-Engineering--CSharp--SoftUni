using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            double money= 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money = money + (i * 5 - 1);
                }

                else 
                {
                    money += toyPrice;
                }
                
            }

            if (money >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {money - washingMachinePrice:F2}");
            }

            else
            {
                Console.WriteLine($"No! {Math.Abs(money - washingMachinePrice):f2}");
            }
        }
    }
}
