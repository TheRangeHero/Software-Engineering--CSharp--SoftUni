using System;

namespace First_Steps_in_Coding___More_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double S = (b1 + b2) * h / 2.0;

            Console.WriteLine($"{S:f2}");
        }
    }
}
