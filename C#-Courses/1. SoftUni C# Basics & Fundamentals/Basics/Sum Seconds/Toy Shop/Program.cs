using System;

public class Program
{
	public static void Main()
	{
		double vacantion = double.Parse(Console.ReadLine());
		int puzzle = int.Parse(Console.ReadLine());
		int dolls = int.Parse(Console.ReadLine());
		int bears = int.Parse(Console.ReadLine());
		int minions = int.Parse(Console.ReadLine());
		int trucks = int.Parse(Console.ReadLine());

		int toysSum = puzzle + dolls + bears + minions + trucks;

		double puzzleLv = puzzle * 2.60;
		double dollsLv = dolls * 3;
		double bearsLv = bears * 4.10;
		double minionsLv = minions * 8.20;
		double trucksLv = trucks * 2;

		double price = puzzleLv + dollsLv + bearsLv + minionsLv + trucksLv;


		if (toysSum >= 50)
		{
			price = price - price * 0.25;
		}

		price = price - price * 0.1;
		double difference = price - vacantion;


		if (difference >= 0)
		{
			Console.WriteLine($"Yes! {difference:F2} lv left.");
		}

		else
		{
			difference = Math.Abs(difference);
			Console.WriteLine($"Not enough money! {difference:F2} lv needed.");
		}

	}
}