using System;

public class Program
{
	public static void Main()
	{
		int a = int.Parse(Console.ReadLine());
		bool isValid = (a >= 100 && a <= 200) || a == 0;
		if (!isValid)
		{
			Console.WriteLine("invalid");
		}
	}
}