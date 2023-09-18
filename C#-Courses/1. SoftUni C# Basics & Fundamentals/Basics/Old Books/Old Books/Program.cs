using System;

public class Program
{
	public static void Main()
	{
		string wantedBook = Console.ReadLine();
		string nextbook = Console.ReadLine();
		int counter = 0;
		bool isWantedBook = false;

		while (nextbook != "No More Books")
		{
			if (nextbook == wantedBook)
			{
				isWantedBook = true;
				break;
			}
			counter += 1;

			nextbook = Console.ReadLine();
		}
		if (isWantedBook)
		{
			Console.WriteLine($"You checked {counter} books and found it.");
		}

		else
		{
			Console.WriteLine($"The book you search is not here!");
			Console.WriteLine($"You checked {counter} books.");
		}

	}
}