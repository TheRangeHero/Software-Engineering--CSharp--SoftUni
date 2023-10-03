using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>, Predicate<string>> printFilterednames = (names, match) =>
            {
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

                            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            printFilterednames(names, n => n.Length <= length);
        }
    }
}
