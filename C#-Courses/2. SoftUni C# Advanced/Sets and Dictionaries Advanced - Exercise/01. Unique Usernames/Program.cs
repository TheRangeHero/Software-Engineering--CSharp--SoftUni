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
            int inputCount = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < inputCount; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }


            foreach (var item in usernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
