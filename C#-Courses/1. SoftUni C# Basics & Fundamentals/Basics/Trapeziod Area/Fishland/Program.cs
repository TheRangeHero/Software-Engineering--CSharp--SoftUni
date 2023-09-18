using System;

namespace Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
			double mackerel = double.Parse(Console.ReadLine());
			double sprat = double.Parse(Console.ReadLine());
			double bonito = double.Parse(Console.ReadLine());
			double horseМackerel = double.Parse(Console.ReadLine());
			int clams = int.Parse(Console.ReadLine());

			double bonitoKg = mackerel + mackerel * 60 / 100.0;
			double bonitoSum = bonito * bonitoKg;
			double horseМackerelKg = sprat + sprat * 80 / 100.0;
			double horseМackerelSum = horseМackerel * horseМackerelKg;
			double clamsSum = clams * 7.50;
			double price = bonitoSum + horseМackerelSum + clamsSum;

			Console.WriteLine($"{price:f2}");
		}
    }
}
