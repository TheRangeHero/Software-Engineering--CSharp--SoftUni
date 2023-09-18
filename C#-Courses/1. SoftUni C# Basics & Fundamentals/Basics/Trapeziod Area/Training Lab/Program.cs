using System;

namespace Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
			double w = double.Parse(Console.ReadLine());
			double h = double.Parse(Console.ReadLine());

			double wCm = w * 100;
			double hCm = h * 100;
			double width = hCm - 100;
			double tables = (int)width / 70;
			double rows = (int)wCm / 120;
			double seats = rows * tables - 3;


			Console.WriteLine(seats);
		}
    }
}
