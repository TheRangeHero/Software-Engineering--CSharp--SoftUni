using System;

namespace Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double S = a * h / 2;

            Console.WriteLine($"{S:f2}");
        }
    }
}
