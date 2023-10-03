using System;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int sum = 0;
		while (n > sum)
		{
			sum += int.Parse(Console.ReadLine());
		}

		Console.WriteLine(sum);
	}
}