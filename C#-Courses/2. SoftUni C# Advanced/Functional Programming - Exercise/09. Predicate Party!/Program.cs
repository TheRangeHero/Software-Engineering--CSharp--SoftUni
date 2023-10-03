using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Party!")
                {
                    break;
                }


                string[] tokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    names.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string> peopleToDouble = names.FindAll(GetPredicate(filter, value));

                    int index = names.FindIndex(GetPredicate(filter, value));
                    if (index >= 0)
                    {
                        names.InsertRange(index, peopleToDouble);

                    }
                }
            }

            if (names.Any())
            {
                Console.WriteLine($"{ string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return s => s.StartsWith(value);
                case "EndsWith":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
