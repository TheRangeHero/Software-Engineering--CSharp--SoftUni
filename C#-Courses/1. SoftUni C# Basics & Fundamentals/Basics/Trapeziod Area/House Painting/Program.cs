using System;

namespace House_Painting
{
    class Program
    {
        static void Main(string[] args)
        {
			double x = double.Parse(Console.ReadLine());
			double y = double.Parse(Console.ReadLine());
			double h = double.Parse(Console.ReadLine());

			double sideWall = x * y;
			double sideWallSum = (2 * sideWall) - 2 * (1.5 * 1.5);
			double frontBack = 2 * (x * x);
			double frontBackSum = frontBack - (1.2 * 2);
			double wallsSum = sideWallSum + frontBackSum;
			double greenPaint = wallsSum / 3.4;

			double roofRectangle = 2 * (x * y);
			double roofTriangle = 2 * ((x * h) / 2);
			double roofSumm = roofRectangle + roofTriangle;
			double redPaint = roofSumm / 4.3;



			Console.WriteLine($"{greenPaint:f2}");
			Console.WriteLine($"{redPaint:f2}");
		}
    }
}
