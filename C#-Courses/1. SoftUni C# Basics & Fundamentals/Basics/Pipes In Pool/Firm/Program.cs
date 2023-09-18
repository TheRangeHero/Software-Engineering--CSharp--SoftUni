using System;

public class Program
{
	public static void Main()
	{
		int neededHours = int.Parse(Console.ReadLine());
		int daysHave = int.Parse(Console.ReadLine());
		int workersOvertime = int.Parse(Console.ReadLine());

		double workingHours = daysHave * 8;
		workingHours = workingHours - workingHours * 0.1;
		double OvertimeHours = workersOvertime * (2 * daysHave);
		double totalHours = workingHours + OvertimeHours;
		totalHours = Math.Floor(totalHours);


		if (totalHours >= neededHours)
		{
			Console.WriteLine($"Yes!{Math.Floor(totalHours - neededHours)} hours left.");
		}
		else
		{
			Console.WriteLine($"Not enough time!{Math.Floor(neededHours - totalHours)} hours needed.");
		}

	}
}