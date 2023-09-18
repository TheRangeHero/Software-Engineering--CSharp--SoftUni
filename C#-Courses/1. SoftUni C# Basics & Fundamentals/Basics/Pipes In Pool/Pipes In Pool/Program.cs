using System;

public class Program
{
	public static void Main()
	{
		int V = int.Parse(Console.ReadLine());
		int P1 = int.Parse(Console.ReadLine());
		int P2 = int.Parse(Console.ReadLine());
		double H = double.Parse(Console.ReadLine());

		double P1L = P1 * H;
		double P2L = P2 * H;
		double lInThePool = P1L + P2L;
		double percentInThePool = lInThePool / V * 100;

		double P1Percent = P1L / lInThePool * 100;
		double P2Percent = P2L / lInThePool * 100;

		if (lInThePool <= V)
		{
			Console.WriteLine($"This pool is {percentInThePool:F2}% full. Pipe 1: {P1Percent:F2}%. Pipe 2: {P2Percent:F2}%.");
		}
		else
		{
			Console.WriteLine($"For {H:F2} hours the pool overflows with {(lInThePool - V):F2} liters");
		}

	}
}