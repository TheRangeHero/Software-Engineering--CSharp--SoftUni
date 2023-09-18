using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneNumber = Console.ReadLine();

            string regex = @"\+359([ \-])2\1[0-9]{3}\1[0-9]{4}\b"; //(\+359 2 [0-9]{3} [0-9]{4}\b)|(\+359-2-[0-9]{3}-[0-9]{4}\b)

            MatchCollection phoneMatches = Regex.Matches(phoneNumber, regex);

            Console.WriteLine(string.Join(", ", phoneMatches));
        }
    }
}
