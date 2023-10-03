using System;

public class Program
{
	public static void Main()
	{
		string name = Console.ReadLine();
		string pass = Console.ReadLine();

		string input = Console.ReadLine();

		while (pass != input)
		{
			input = Console.ReadLine();
		}

		Console.WriteLine($"Welcome {name}!");
	}
}