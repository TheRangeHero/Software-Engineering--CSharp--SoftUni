using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double s = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            double time = m * timeForMeter;
            double delay = m / 15;
            delay = Math.Floor(delay);
            delay = delay * 12.5;
            double finishTime = time + delay;

            if (finishTime < s)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finishTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(finishTime - s):F2} seconds slower.");
            }



        }
    }
}
