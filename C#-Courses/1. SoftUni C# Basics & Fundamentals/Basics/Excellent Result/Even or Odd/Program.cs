using System;

namespace Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
			int num = int.Parse(Console.ReadLine());
			bool even = num % 2 == 0;
			if (even)
			{
				Console.WriteLine("even");
			}
			else
			{
				Console.WriteLine("odd");
			}
		}
    }
}
