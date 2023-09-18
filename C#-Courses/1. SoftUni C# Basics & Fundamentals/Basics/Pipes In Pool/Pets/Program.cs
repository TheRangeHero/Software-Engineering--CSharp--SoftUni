using System;

public class Program
{
	public static void Main()
	{
		int daysAway = int.Parse(Console.ReadLine());
		int foodLeft = int.Parse(Console.ReadLine());
		double dogFoodKg = double.Parse(Console.ReadLine());
		double catFoodKg = double.Parse(Console.ReadLine());
		double turtleFoodG = double.Parse(Console.ReadLine());

		double FoodForDog = daysAway * dogFoodKg;
		double FoodForCat = daysAway * catFoodKg;
		double FoodForTurtle = (daysAway * turtleFoodG) / 1000;

		double requiredFood = FoodForDog + FoodForCat + FoodForTurtle;
		if (requiredFood <= foodLeft)
		{
			Console.WriteLine($"{(Math.Floor(foodLeft - requiredFood)) } kilos of food left.");
		}
		else
		{
			double foodNeed = requiredFood - foodLeft;
			Console.WriteLine($"{(Math.Ceiling(requiredFood - foodLeft))} more kilos of food are needed. ");
		}
	}
}