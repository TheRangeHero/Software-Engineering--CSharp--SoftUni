using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            bool isFound = false;

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string currentClothing = input[j];
                    if (!wardrobe[color].ContainsKey(currentClothing))
                    {
                        wardrobe[color].Add(currentClothing, 0);
                    }
                    wardrobe[color][currentClothing]++;
                }

            }

            string[] findParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach (var colorOfCloths in wardrobe)
            {
                Console.WriteLine($"{colorOfCloths.Key} clothes:");

                foreach (var cloth in colorOfCloths.Value)
                {
                    string toPrint = $"* {cloth.Key} - {cloth.Value}";
                    if (colorOfCloths.Key == findParams[0] && cloth.Key == findParams[1])
                    {
                        toPrint += " (found!)";
                    }
                    Console.WriteLine(toPrint);
                }
            }
        }
    }
}
