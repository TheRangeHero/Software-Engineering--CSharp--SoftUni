using System;

namespace Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
			int chicken = int.Parse(Console.ReadLine());
			int fish = int.Parse(Console.ReadLine());
			int vegetarian = int.Parse(Console.ReadLine());

			double menuPrice = (chicken * 10.35) + (fish * 12.40) + (vegetarian * 8.15);
			double dessert = menuPrice * 20 / 100;
			double price = menuPrice + dessert + 2.50;

			Console.WriteLine(price);
		}
    }
}
