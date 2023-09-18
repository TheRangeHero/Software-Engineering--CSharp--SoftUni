using System;

public class Program
{
	public static void Main()
	{
		int hours = int.Parse(Console.ReadLine());
		string day = Console.ReadLine();

		if (day == "Monday")
		{
			if (hours >= 10 && hours <= 18)
			{
				Console.Write("open");
			}
			else
			{
				Console.Write("closed");
			}
		}

		else if (day == "Tuesday")
		{
			if (hours >= 10 && hours <= 18)
			{
				Console.Write("open");
			}
			else
			{
				Console.Write("closed");
			}
		}

		else if (day == "Wednesday")
		{
			if (hours >= 10 && hours <= 18)
			{
				Console.Write("open");
			}
			else
			{
				Console.Write("closed");
			}
		}

		else if (day == "Thursday")
		{
			if (hours >= 10 && hours <= 18)
			{
				Console.Write("open");
			}
			else
			{
				Console.Write("closed");
			}
		}

		else if (day == "Friday")
		{
			if (hours >= 10 && hours <= 18)
			{
				Console.Write("open");
			}
			else
			{
				Console.Write("closed");
			}
		}

		else if (day == "Saturday")
		{
			if (hours >= 10 && hours <= 18)
			{
				Console.Write("open");
			}
			else
			{
				Console.Write("closed");
			}
		}

		else if (day == "Sunday")
		{
			Console.WriteLine("closed");
		}
	}
}