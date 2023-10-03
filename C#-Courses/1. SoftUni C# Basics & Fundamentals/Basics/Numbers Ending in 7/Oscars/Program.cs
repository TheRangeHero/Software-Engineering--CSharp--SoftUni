using System;

public class Program
{
	public static void Main()
	{
		string actorName = Console.ReadLine();
		double pointsAcademy = double.Parse(Console.ReadLine());
		int nJuges = int.Parse(Console.ReadLine());

		double points = pointsAcademy;

		for (int i = 1; i <= nJuges; i++)
		{
			string judgeName = Console.ReadLine();
			double pointsJudge = double.Parse(Console.ReadLine());

			points += ((judgeName.Length * pointsJudge) / 2);

			if (points >= 1250.5)
			{
				Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {points:f1}!");
				break;
			}

		}

		if (points < 1250.5)
		{
			Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - points):f1} more!");
		}
	}
}