using System;

namespace Weather_Forecast___Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
			double degrees = double.Parse(Console.ReadLine());

			bool hot = degrees >= 26.00 && degrees <= 35;
			bool warm = degrees >= 20.1 && degrees <= 25.9;
			bool mild = degrees >= 15.00 && degrees <= 20.00;
			bool cool = degrees >= 12.00 && degrees <= 14.9;
			bool cold = degrees >= 5.00 && degrees <= 11.9;

			if (hot)
			{
				Console.WriteLine("Hot");
			}
			else if (warm)
			{
				Console.WriteLine("Warm");
			}
			else if (mild)
			{
				Console.WriteLine("Mild");
			}
			else if (cool)
			{
				Console.WriteLine("Cool");
			}
			else if (cold)
			{
				Console.WriteLine("Cold");
			}
			else
			{
				Console.WriteLine("unknown");
			}
		}
    }
}
