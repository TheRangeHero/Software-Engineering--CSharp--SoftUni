using System;

namespace Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double Inches = double.Parse(Console.ReadLine());

            double Centimeters = Inches * 2.54;
            Console.WriteLine(Centimeters);
        }
    }
}
