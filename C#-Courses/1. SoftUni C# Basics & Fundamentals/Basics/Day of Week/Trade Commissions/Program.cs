using System;

public class Program
{
	public static void Main()
	{
		string city = Console.ReadLine();
		double sells = double.Parse(Console.ReadLine());

		double commission = 0.0;

		if (sells >= 0 && sells <= 500)
		{
			if (city == "Sofia")
			{
				commission = 5;
			}

			else if (city == "Varna")
			{
				commission = 4.5;
			}

			else if (city == "Plovdiv")
			{
				commission = 5.5;
			}

			else
			{
				Console.WriteLine("error");
			}
		}

		else if (sells > 500 && sells <= 1000)
		{
			if (city == "Sofia")
			{
				commission = 7;
			}

			else if (city == "Varna")
			{
				commission = 7.5;
			}

			else if (city == "Plovdiv")
			{
				commission = 8;
			}

			else
			{
				Console.WriteLine("error");
			}
		}

		else if (sells > 1000 && sells <= 10000)
		{
			if (city == "Sofia")
			{
				commission = 8;
			}

			else if (city == "Varna")
			{
				commission = 10;
			}

			else if (city == "Plovdiv")
			{
				commission = 12;
			}

			else
			{
				Console.WriteLine("error");
			}
		}

		else if (sells > 10000)
		{
			if (city == "Sofia")
			{
				commission = 12;
			}

			else if (city == "Varna")
			{
				commission = 13;
			}

			else if (city == "Plovdiv")
			{
				commission = 14.5;
			}

			else
			{
				Console.WriteLine("error");
			}
		}
		else
		{
			Console.WriteLine("error");
		}
		double result = sells * (commission / 100.0);

		if (result != 0)
		{
			Console.WriteLine($"{result:F2}");
		}
	}
}