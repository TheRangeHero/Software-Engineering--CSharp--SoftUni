using System;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int examTime = (examHour * 60) + examMinutes;
            int personTime = (hour * 60) + minutes;
            int exactTime = personTime - examTime;

            string time = "";

            if (exactTime <= 0 && exactTime >= -30)
            {
                time = "On time";
            }

            else if (exactTime < -30)
            {
                time = "Early";
            }

            else if (exactTime > 0)
            {
                time = "Late";
            }

            Console.WriteLine(time);

            if (exactTime < 0 && exactTime > -60)
            {
                Console.WriteLine($"{Math.Abs(exactTime)} minutes before the start");
            }

            else if (exactTime <= -60)
            {
                int hours = exactTime / 60;
                int minutess = exactTime % 60;
                if (minutess > -10)
                {
                    Console.WriteLine($"{Math.Abs(hours)}:0{Math.Abs(minutess)} hours  before the start");
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(hours)}:{Math.Abs(minutess)} hours  before the start");
                }
            }

            else if (exactTime > 0 && exactTime < 60)
            {
                Console.WriteLine($"{exactTime} minutes after the start");
            }

            else if (exactTime >= 60)
            {
                double hours = exactTime / 60;
                double minutess = exactTime % 60;
                if (minutess < 10)
                {
                    Console.WriteLine($"{hours}:0{minutess} hours  after the start");
                }
                else
                {
                    Console.WriteLine($"{hours}:{minutess} hours  after the start");
                }
            }
        }
    }
}
