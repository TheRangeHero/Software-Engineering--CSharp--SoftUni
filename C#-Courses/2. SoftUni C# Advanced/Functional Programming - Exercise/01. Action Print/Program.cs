using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> namePrinter = n =>
            {
                Console.WriteLine(string.Join(Environment.NewLine, n));
            };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            namePrinter(names);
        }
    }
}
