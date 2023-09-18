using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkEqualOrGreater = (name, sum) =>
            name.Sum(ch => ch) >= sum;

            Func<string[], int, Func<string, int, bool>, string> getFirstName = (names, sum, match) =>                
                     names.FirstOrDefault(name => match(name, sum));                 

            int number = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(getFirstName(names,number,checkEqualOrGreater));
        }
    }
}
