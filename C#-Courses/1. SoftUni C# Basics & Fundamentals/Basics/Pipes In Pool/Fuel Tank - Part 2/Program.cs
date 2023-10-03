using System;

public class Program
{
	public static void Main()
	{
		string fuel = Console.ReadLine();
		double liters = double.Parse(Console.ReadLine());
		string card = Console.ReadLine();

		double discountGas = 0.93 - 0.08;
		double discountGasoline = 2.22 - 0.18;
		double discountDiesel = 2.33 - 0.12;



		double price = 0.0;
		price = discountGas * liters;
		price = price - price * 0.1;



		if (fuel == "Gas" && card == "Yes")
		{
			if (liters < 20)
			{
				price = discountGas * liters;
			}
			else if (liters >= 20 && liters <= 25)
			{
				price = discountGas * liters;
				price = price - price * 0.08;
			}
			else if (liters > 25)
			{
				price = discountGas * liters;
				price = price - price * 0.1;
			}
		}
		else if (fuel == "Gas" && card == "No")
		{
			if (liters < 20)
			{
				price = 0.93 * liters;
			}
			else if (liters >= 20 && liters <= 25)
			{
				price = 0.93 * liters;
				price = price - price * 0.08;
			}
			else if (liters > 25)
			{
				price = 0.93 * liters;
				price = price - price * 0.1;
			}
		}
		else if (fuel == "Gasoline" && card == "Yes")
		{
			if (liters < 20)
			{
				price = discountGasoline * liters;
			}
			else if (liters >= 20 && liters <= 25)
			{
				price = discountGasoline * liters;
				price = price - price * 0.08;
			}
			else if (liters > 25)
			{
				price = discountGasoline * liters;
				price = price - price * 0.1;
			}
		}
		else if (fuel == "Gasoline" && card == "No")
		{
			if (liters < 20)
			{
				price = 2.22 * liters;
			}
			else if (liters >= 20 && liters <= 25)
			{
				price = 2.22 * liters;
				price = price - price * 0.08;
			}
			else if (liters > 25)
			{
				price = 2.22 * liters;
				price = price - price * 0.1;
			}
		}
		else if (fuel == "Diesel" && card == "Yes")
		{
			if (liters < 20)
			{
				price = discountDiesel * liters;
			}
			else if (liters >= 20 && liters <= 25)
			{
				price = discountDiesel * liters;
				price = price - price * 0.08;
			}
			else if (liters > 25)
			{
				price = discountDiesel * liters;
				price = price - price * 0.1;
			}
		}
		else if (fuel == "Diesel" && card == "No")
		{
			if (liters < 20)
			{
				price = 2.33 * liters;
			}
			else if (liters >= 20 && liters <= 25)
			{
				price = 2.33 * liters;
				price = price - price * 0.08;
			}
			else if (liters > 25)
			{
				price = 2.33 * liters;
				price = price - price * 0.1;
			}
		}
		Console.WriteLine($"{price:F2} lv.");

	}
}