using System;

public class Program
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		for (int i = 1; i <= 9; i++)
		{
			for (int o = 1; o <= 9; o++)
			{
				for (int u = 1; u <= 9; u++)
				{
					for (int y = 1; y <= 9; y++)
					{
						if (n % i == 0 && n % o == 0 && n % u == 0 && n % y == 0)
						{
							Console.Write($"{i}{o}{u}{y} ");
						}
					}
				}
			}
		}
	}
}