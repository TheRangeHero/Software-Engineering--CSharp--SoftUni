using System;

public class Program
{
	public static void Main()
	{
		int X = int.Parse(Console.ReadLine()); // X кв.м е лозето 
		double Y = double.Parse(Console.ReadLine()); // Y грозде за един кв.м 
		int Z = int.Parse(Console.ReadLine()); //Z нужни литри вино 
		int workers = int.Parse(Console.ReadLine()); // брой работници

		double harvest = X * Y;
		double harvestForVine = harvest * 0.4;
		double vine = harvestForVine / 2.5;


		if (vine < Z)
		{
			double vineNeeded = Z - vine;
			Console.WriteLine($"It will be a tough winter! More {Math.Floor(vineNeeded)} liters wine needed.");
		}
		else
		{
			double vineLeft = vine - Z;
			double vinePerPerson = vineLeft / workers;
			Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(vine)} liters.");
			Console.WriteLine($"{Math.Ceiling(vineLeft)} liters left -> {Math.Ceiling(vinePerPerson)} liters per person.");
		}
	}
}