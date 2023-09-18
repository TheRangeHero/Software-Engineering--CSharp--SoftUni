using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-za-z\s]+)<<(?<price>[0-9]+(.[0-9]+)?)!(?<quantity>\d+)";

            string input = Console.ReadLine();

            List<string> listOfFurnitures = new List<string>();

            double totalPrice = 0;

            while (input!= "Purchase")
            {

                Match matches = Regex.Match(input, regex, RegexOptions.IgnoreCase);

                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    double price = double.Parse(matches.Groups["price"].Value);
                    int quantity = int.Parse(matches.Groups["quantity"].Value);

                    listOfFurnitures.Add(name);

                    totalPrice += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            listOfFurnitures.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
