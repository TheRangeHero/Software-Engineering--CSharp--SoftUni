using System;

namespace Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());
            string[] dayOfWeeks =
            {
             "Monday",
             "Tuesday",
             "Wednesday",
             "Thursday",
             "Friday",
             "Saturday",
             "Sunday"
            };

            if (dayNumber >= 1 && dayNumber <= 7)
            {
                Console.WriteLine(dayOfWeeks[dayNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
