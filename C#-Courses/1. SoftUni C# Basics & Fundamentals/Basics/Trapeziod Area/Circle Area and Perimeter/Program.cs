using System;

namespace Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
			double r = double.Parse(Console.ReadLine());
			double pi = Math.PI;
			double squareR = Math.Pow(r, 2);

			double S = pi * squareR;
			//double sRound = Math.Round(S,2);
			double P = 2 * pi * r;

			Console.WriteLine(Math.Round(S, 2));
			Console.WriteLine(Math.Round(P, 2));
		}
    }
}
