using System;

public class Program
{
	public static void Main()
	{
		string word = Console.ReadLine();

		if (word == "banana" || word == "apple" || word == "kiwi" || word == "cherry" || word == "lemon" || word == "grapes")
		{
			Console.WriteLine("fruit");
		}
		else if (word == "tomato" || word == "cucumber" || word == "pepper" || word == "carrot")
		{
			Console.WriteLine("vegetable");
		}
		else
		{
			Console.WriteLine("unknown");
		}
	}
}



/*using System;
					
public class Program
{
	public static void Main()
	{
	 	string word = Console.ReadLine();
		
		switch (word)
		{
			case "banana":
			case "apple":
			case "kiwi":
			case "cherry":
			case "lemon":
			case "grapes":
				Console.WriteLine("fruit");
				break;
			case "tomato":
			case "cucumber":
			case "pepper":
			case "carrot":
				Console.WriteLine("vegetable");
				break;
			default:
				Console.WriteLine("unknown");
				break;
		}
	}
}