using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            //HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < input; i++)
            {

                string[] splitted = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                elements.UnionWith(splitted);
                //foreach (var item in splitted)
                //{
                //    elements.Add(item);
                //}
            }

            //elements = elements.OrderBy(x => x).ToHashSet();

            Console.WriteLine(string.Join(' ', elements));
        }
    }
}
