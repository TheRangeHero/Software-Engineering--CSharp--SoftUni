using System;

public class Program
{
	public static void Main()
	{
		string input = Console.ReadLine();

		int minNumber = int.MaxValue;
		while (input != "Stop")
		{
			int n = int.Parse(input);
			if (n < minNumber)
			{
				minNumber = n;
			}
			input = Console.ReadLine();
		}
		Console.WriteLine(minNumber);
	}
}