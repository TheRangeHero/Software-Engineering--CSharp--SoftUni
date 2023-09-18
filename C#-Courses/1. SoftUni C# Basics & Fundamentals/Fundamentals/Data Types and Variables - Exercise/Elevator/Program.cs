using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            double remainingCourses = (double)peopleCount / capacity;

            Console.WriteLine(Math.Ceiling(remainingCourses));
        }
    }
}
