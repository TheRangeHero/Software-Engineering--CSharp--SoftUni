using System;

public class Program
{
	public static void Main()
	{
		string input = Console.ReadLine();
		int prime = 0;
		int nonPrime = 0;
		

		while (input != "stop")
		{
			int number = int.Parse(input);
			if (number < 0)
			{
				Console.WriteLine("Number is negative.");
				input = Console.ReadLine();
				continue;
			}
			bool isPrime = true;

			for (int i = 2; i < number - 1; i++)
			{
				if (number % i == 0)
				{ 
				isPrime = false;
				break;
				}
			}

			if (isPrime)
			{
				prime += number;
			}
			else
			{
				nonPrime += number;
			}
			input = Console.ReadLine();
		}
		Console.WriteLine($"Sum of all prime numbers is: {prime} \nSum of all non prime numbers is: {nonPrime}");
	}
}