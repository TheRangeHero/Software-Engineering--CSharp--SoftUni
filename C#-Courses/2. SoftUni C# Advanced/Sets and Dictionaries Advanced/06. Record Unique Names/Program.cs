using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();


            for (int i = 0; i < inputCount; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
