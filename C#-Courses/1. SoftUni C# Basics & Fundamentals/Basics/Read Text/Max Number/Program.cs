using System;

public class Program
{
	public static void Main()
	{
		string input = Console.ReadLine();

		int maxNumb = int.MinValue;

		while (input != "Stop")
		{
			int n = int.Parse(input);
			if (n > maxNumb)
			{
				maxNumb = n;
			}
			input = Console.ReadLine();
		}

		Console.WriteLine(maxNumb);
	}
}