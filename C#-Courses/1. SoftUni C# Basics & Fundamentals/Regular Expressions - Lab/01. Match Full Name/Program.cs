using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<firstName>\b[A-Z][a-z]+) (?<lastName>[A-Z][a-z]+\b)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            
                Console.WriteLine(string.Join(" ", matches));
            

        }
    }
}
