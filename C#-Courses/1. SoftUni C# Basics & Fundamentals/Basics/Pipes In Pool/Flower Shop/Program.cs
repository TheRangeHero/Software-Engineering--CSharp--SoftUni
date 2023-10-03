using System;

public class Program
{
	public static void Main()
	{
		int magnolia = int.Parse(Console.ReadLine());
		int hyacinths = int.Parse(Console.ReadLine());
		int rose = int.Parse(Console.ReadLine());
		int cactus = int.Parse(Console.ReadLine());
		double presentPrice = double.Parse(Console.ReadLine());

		double magnoliaLv = magnolia * 3.25;
		double hyacinthsLv = hyacinths * 4;
		double roseLv = rose * 3.50;
		double cactusLv = cactus * 8;
		double totalMoney = magnoliaLv + hyacinthsLv + roseLv + cactusLv;
		double moneyForPresent = totalMoney - totalMoney * 0.05;

		if (presentPrice > moneyForPresent)
		{
			Console.WriteLine($"She will have to borrow {Math.Ceiling(presentPrice - moneyForPresent)} leva.");
		}
		else
		{
			Console.WriteLine($"She is left with {Math.Floor(moneyForPresent - presentPrice)} leva.");
		}

	}
}