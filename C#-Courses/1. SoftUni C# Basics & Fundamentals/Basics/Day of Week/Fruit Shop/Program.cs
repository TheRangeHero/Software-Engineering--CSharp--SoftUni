using System;

public class Program
{
	public static void Main()
	{
		string fruit = Console.ReadLine();
		string day = Console.ReadLine();
		double quantity = double.Parse(Console.ReadLine());

		double price = 0.0;

		switch (day)
		{
			case "Monday":
			case "Tuesday":
			case "Wednesday":
			case "Thursday":
			case "Friday":
				switch (fruit)
				{
					case "banana":
						price = 2.50;
						break;
					case "apple":
						price = 1.20;
						break;
					case "orange":
						price = 0.85;
						break;
					case "grapefruit":
						price = 1.45;
						break;
					case "kiwi":
						price = 2.70;
						break;
					case "pineapple":
						price = 5.50;
						break;
					case "grapes":
						price = 3.85;
						break;
					default:
						Console.WriteLine("error");
						break;
				}
				break;
			case "Saturday":
			case "Sunday":
				switch (fruit)
				{
					case "banana":
						price = 2.70;
						break;
					case "apple":
						price = 1.25;
						break;
					case "orange":
						price = 0.90;
						break;
					case "grapefruit":
						price = 1.60;
						break;
					case "kiwi":
						price = 3.00;
						break;
					case "pineapple":
						price = 5.60;
						break;
					case "grapes":
						price = 4.20;
						break;
					default:
						Console.WriteLine("error");
						break;
				}
				break;
			default:
				Console.WriteLine("error");
				break;
		}

		if (price != 0)
		{
			Console.WriteLine($"{quantity * price:f2}");
		}

	}
}




/*using System;
					
public class Program
{
	public static void Main()
	{
		string fruit = Console.ReadLine();
		string day = Console.ReadLine();
		double quantity = double.Parse(Console.ReadLine());
		
		double price = 0.0;
		
		if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" )
			{
				if (fruit == "banana")
				{
				price = 2.50;
				}
			
				else if (fruit == "apple")
				{
				price = 1.20;
				}
				
				else if (fruit == "orange")
				{
				price = 0.85;
				}
				
				else if (fruit == "grapefruit")
				{
				price = 1.45;
				}
			
				else if (fruit == "kiwi")
				{
				price = 2.70;
				}
			
				else if (fruit == "pineapple")
				{
				price = 5.50;
				}
			
				else if (fruit == "grapes")
				{
				price = 3.85;
				}
			
				else
				{
				Console.WriteLine("error");
				}
			}
			else if (day == "Saturday" || day == "Sunday")
			{
				if (fruit == "banana")
				{
				price = 2.70;
				}
			
				else if (fruit == "apple")
				{
				price = 1.25;
				}
				
				else if (fruit == "orange")
				{
				price = 0.90;
				}
				
				else if (fruit == "grapefruit")
				{
				price = 1.60;
				}
			
				else if (fruit == "kiwi")
				{
				price = 3.00;
				}
			
				else if (fruit == "pineapple")
				{
				price = 5.60;
				}
			
				else if (fruit == "grapes")
				{
				price = 4.20;
				}
			
				else
				{
				Console.WriteLine("error");
				}
			}
			else
			{
			Console.WriteLine("error");
			}
		double total = price * quantity;
		
		if (total != 0)
		{
		Console.WriteLine($"{total:F2}");
		}
	}
}