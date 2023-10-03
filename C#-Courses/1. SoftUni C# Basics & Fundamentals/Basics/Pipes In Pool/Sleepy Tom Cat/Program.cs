using System;

public class Program
{
	public static void Main()
	{
		int daysOff = int.Parse(Console.ReadLine());
		int workingDays = 365 - daysOff;
		double PlayTime = (daysOff * 127) + (workingDays * 63);

		double norm = 30000 - PlayTime;
		norm = Math.Abs(norm);
		double HH = norm / 60;
		double mm = norm % 60;
		if (PlayTime > 30000)
		{
			Console.WriteLine($"Tom will run away");
			Console.WriteLine($"{Math.Floor(HH)} hours and {Math.Floor(mm)} minutes more for play");
		}
		else
		{
			Console.WriteLine($"Tom sleeps well");
			Console.WriteLine($"{Math.Floor(HH)} hours and {Math.Floor(mm)} minutes less for play");
		}
	}
}