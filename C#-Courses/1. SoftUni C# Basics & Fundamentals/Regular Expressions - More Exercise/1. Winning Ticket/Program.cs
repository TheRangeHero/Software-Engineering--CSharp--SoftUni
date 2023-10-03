using System;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                if (item.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string pattern = @"([$|@|#|\^]{6,}).+?\1";

                string textToProfe = item.Insert(10, " ");
                Match match = Regex.Match(textToProfe, pattern);

                if (!match.Success)
                {
                    Console.WriteLine($"ticket \"{item}\" - no match");
                    continue;
                }

                string symbol = match.Groups[1].Value[0].ToString();
                int count = match.Groups[1].Value.Length;

                if (count == 10)
                    Console.WriteLine($"ticket \"{item}\" - {count}{symbol} Jackpot!");
                else
                    Console.WriteLine($"ticket \"{item}\" - {count}{symbol}");
            }
        }
    }
}
