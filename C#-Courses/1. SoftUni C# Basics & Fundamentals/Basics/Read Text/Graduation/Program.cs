using System;

public class Program
{
	public static void Main()
	{
		string name = Console.ReadLine();

		int grade = 1;

		double gradeSum = 0;
		int counter = 0;

		while (grade <= 12)
		{
			double yearlygrade = double.Parse(Console.ReadLine());

			if (yearlygrade < 4)
			{
				counter++;
				if (counter > 1)
				{
					break;
				}
				continue;
			}

			gradeSum += yearlygrade;
			grade++;
		}
		if (grade > 12)

		{
			double average = gradeSum / (grade - 1);
			Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
		}
		else
		{
			Console.WriteLine($"{name} has been excluded at {grade} grade");
		}
	}
}