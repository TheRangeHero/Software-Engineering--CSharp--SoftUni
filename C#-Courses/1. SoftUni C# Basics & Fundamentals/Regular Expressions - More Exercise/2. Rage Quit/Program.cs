using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"((?<letters>[\D]+)(?<numbers>[\d]+))";
            StringBuilder sb = new StringBuilder();
            int count = 0;
            MatchCollection match = Regex.Matches(input, pattern);

            foreach (Match item in match)
            {
                string message = item.Groups["letters"].Value;
                int repeats = int.Parse(item.Groups["numbers"].Value);

                for (int i = 0; i < repeats; i++)
                {
                    sb.Append(message.ToUpper());
                }

            }
                count = sb.ToString().Distinct().Count();

                Console.WriteLine($"Unique symbols used: {count}");
                Console.WriteLine(sb);
        }
    }
}
