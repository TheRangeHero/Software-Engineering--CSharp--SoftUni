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
            HashSet<string> guestsVIPID = new HashSet<string>();
            HashSet<string> guestsGenericID = new HashSet<string>();
            string pattern = @"^\d";
            string input = Console.ReadLine();



            while (true)
            {
                if (input == "PARTY")
                {
                    break;
                }

                if (Regex.IsMatch(input, pattern))
                {
                    guestsVIPID.Add(input);
                }
                else
                {
                    guestsGenericID.Add(input);
                }

                input = Console.ReadLine();
            }

            while (true)
            {
                if (input == "END")
                {
                    break;
                }

                if (Regex.IsMatch(input, pattern))
                {
                    guestsVIPID.Remove(input);
                }
                else
                {
                    guestsGenericID.Remove(input);
                }


                input = Console.ReadLine();
            }

            int counnt = guestsGenericID.Count + guestsVIPID.Count;

            Console.WriteLine(counnt);
            foreach (var item in guestsVIPID)
            {
                Console.WriteLine(item);
            }
            foreach (var item in guestsGenericID)
            {
                Console.WriteLine(item);
            }
        }
    }
}
