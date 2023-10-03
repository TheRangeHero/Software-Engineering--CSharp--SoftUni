using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int inputCount = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continentCountriesCities = new Dictionary<string, Dictionary<string, List<string>>>();



            for (int i = 0; i < inputCount; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = tokens[0];
                string countries = tokens[1];
                string city = tokens[2];


                if (!continentCountriesCities.ContainsKey(continent))
                {
                    continentCountriesCities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continentCountriesCities[continent].ContainsKey(countries))
                {
                    continentCountriesCities[continent].Add(countries, new List<string>());
                }

                continentCountriesCities[continent][countries].Add(city);
            }

            foreach (var continent in continentCountriesCities)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var item in continent.Value)
                {
                    Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)}");
                }

            }
        }
    }
}
