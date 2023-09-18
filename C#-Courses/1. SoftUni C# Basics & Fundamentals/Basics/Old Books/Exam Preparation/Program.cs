using System;

public class Program
{
	public static void Main()
	{
		int allowedBadGrades = int.Parse(Console.ReadLine());


		int failedTimesCounter = 0;
		string lastProblem = "";
		double gradeSum = 0;
		int solvedtaskCounter = 0;
		bool isFlailed = true;

		while (failedTimesCounter < allowedBadGrades)
		{
			string taskName = Console.ReadLine();
			if (taskName == "Enough")
			{
				isFlailed = false;
				break;
			}


			int taskGrade = int.Parse(Console.ReadLine());
			if (taskGrade <= 4)
			{
				failedTimesCounter++;
			}

			gradeSum += taskGrade;
			lastProblem = taskName;
			solvedtaskCounter++;

		}

		if (isFlailed)
		{
			Console.WriteLine($"You need a break, {failedTimesCounter} poor grades.");

		}
		else
		{
			Console.WriteLine($"Average score: {gradeSum / solvedtaskCounter:F2}");
			Console.WriteLine($"Number of problems: {solvedtaskCounter}");
			Console.WriteLine($"Last problem: {lastProblem}");
		}

	}
}