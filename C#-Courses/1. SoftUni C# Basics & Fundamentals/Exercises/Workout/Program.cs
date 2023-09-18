using System;

namespace Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double dayOneKm = double.Parse(Console.ReadLine());


            double kmAtDay = dayOneKm;
            double ksIncrease = 0;

            double totalKms = dayOneKm;
            for (int i = 0; i < days; i++)
            {
                
                int percent = int.Parse(Console.ReadLine());
                 
                ksIncrease = kmAtDay * (percent / 100.0);
                kmAtDay += ksIncrease;

                totalKms += kmAtDay;
            }

            if (totalKms >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalKms - 1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000- totalKms)} more kilometers");
            }
        }
    }
}
