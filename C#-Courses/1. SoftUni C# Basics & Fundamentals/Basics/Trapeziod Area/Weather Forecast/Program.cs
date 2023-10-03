using System;

namespace Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
			string warm = Console.ReadLine();

			if (warm == "sunny")
			{
				Console.WriteLine("It's warm outside!");
			}
			else
			{
				Console.WriteLine("It's cold outside!");
			}
		}
    }
}
