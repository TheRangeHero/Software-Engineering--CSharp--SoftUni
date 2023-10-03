using System;

public class Program
{
	public static void Main()
	{
		string money = Console.ReadLine();

		double account = 0;

		while (money != "NoMoreMoney")
		{
			double sum = double.Parse(money);

			if (sum < 0)
			{
				Console.WriteLine("Invalid operation!");
				break;
			}

			account += sum;
			Console.WriteLine($"Increase: {sum:f2}");


			money = Console.ReadLine();
		}
		Console.WriteLine($"Total: {account:f2}");

	}
}