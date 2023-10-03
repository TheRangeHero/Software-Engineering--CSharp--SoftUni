using System;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
			int nylon = int.Parse(Console.ReadLine());
			int paint = int.Parse(Console.ReadLine());
			int thinner = int.Parse(Console.ReadLine());
			int hours = int.Parse(Console.ReadLine());

			double nylonSum = (nylon + 2) * 1.50;
			double paintSum = (paint + paint * 0.1) * 14.50;
			double ThinnerSum = thinner * 5.00;
			double materialsTotal = nylonSum + paintSum + ThinnerSum + 0.40;
			double workman = (materialsTotal * 0.3) * hours;
			double totalPrice = materialsTotal + workman;
			Console.WriteLine(totalPrice);
		}
    }
}
