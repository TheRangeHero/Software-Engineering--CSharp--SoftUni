using System;

public class Program
{
	public static void Main()
	{
		int tournamentsCount = int.Parse(Console.ReadLine());
		int pointsStarting = int.Parse(Console.ReadLine());

		double pointsW = 2000;
		double pointsF = 1200;
		double pointsSF = 720;

		double wins = 0;
		double finals = 0;
		double semifinals = 0;



		for (int i = 1; i <= tournamentsCount; i++)
		{
			string stage = Console.ReadLine();

			if (stage == "W")
			{
				wins += 1;
			}

			else if (stage == "F")
			{
				finals += 1;
			}

			else
			{
				semifinals += 1;
			}

		}

		double totalPoints = (pointsW * wins) + (pointsF * finals) + (pointsSF * semifinals) + pointsStarting;

		double pointsAverage = Math.Floor(((pointsW * wins) + (pointsF * finals) + (pointsSF * semifinals)) / tournamentsCount);

		double percetnageWon = (wins / tournamentsCount) * 100;

		Console.WriteLine($"Final points: {totalPoints}");
		Console.WriteLine($"Average points: {pointsAverage}");
		Console.WriteLine($"{percetnageWon:F2}%");

	}
}