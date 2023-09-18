using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = double.Parse(Console.ReadLine());
            int totalStudents = int.Parse(Console.ReadLine());
            double singleSaberPrice = double.Parse(Console.ReadLine());
            double singleRobePrice = double.Parse(Console.ReadLine());
            double singelBeltPrice = double.Parse(Console.ReadLine());


            double totalSaberNumber = Math.Ceiling(totalStudents * 1.10);
            double numbersOfFreeBelts = Math.Floor(totalStudents / 6.0);

            double totalSaberPrice = totalSaberNumber * singleSaberPrice;
            double totalRobePrice = totalStudents * singleRobePrice;
            double totalBeltProce = (totalStudents - numbersOfFreeBelts) * singelBeltPrice;

            double totalCost = totalSaberPrice + totalRobePrice + totalBeltProce;

            if (totalMoney >= totalCost)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:f2}lv.");
            }
            else
            {
                double moneyNeeded = Math.Abs(totalCost - totalMoney);
                Console.WriteLine($"John will need {moneyNeeded:f2}lv more.");
            }
        }
    }
}
