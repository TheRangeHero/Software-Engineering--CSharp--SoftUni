using System;

public class Program
{
	public static void Main()
	{
		int a = int.Parse(Console.ReadLine());

		if (a >= -100 && a <= 100 && a != 0)
		{
			Console.WriteLine("Yes");
		}
		else
		{
			Console.WriteLine("No");
		}
	}
}