using System;

public class Program
{
	public static void Main()
	{
		double n = double.Parse(Console.ReadLine()); // брой километри
		string type = Console.ReadLine(); //ден или нощ

		if (n < 20 && type == "day")
		{
			n = 0.70 + n * 0.79;
			Console.WriteLine($"{n:F2}");
		}
		else if (n < 20 && type == "night")
		{
			n = 0.70 + n * 0.90;
			Console.WriteLine($"{n:F2}");
		}
		else if (n >= 20 && n < 100)
		{
			n = n * 0.09;
			Console.WriteLine($"{n:F2}");
		}
		else if (n >= 100)
		{
			n = n * 0.06;
			Console.WriteLine($"{n:F2}");
		}
	}
}