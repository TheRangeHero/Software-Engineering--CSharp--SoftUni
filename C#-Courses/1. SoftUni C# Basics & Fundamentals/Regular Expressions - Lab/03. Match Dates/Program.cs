using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();

            string pattern = @"(?<day>[\d]{2})(?<separator>[\/\-\.])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})";

            MatchCollection matches = Regex.Matches(date, pattern);

            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var month = match.Groups["month"].Value;
                var year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");

                //Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
