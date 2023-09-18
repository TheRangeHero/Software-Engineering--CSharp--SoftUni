using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();


            Dictionary<char, int> symbolOccurrences = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {

                if (!symbolOccurrences.ContainsKey(text[i]))
                {
                    symbolOccurrences.Add(text[i], 0);
                }
                symbolOccurrences[text[i]]++;
            }

            symbolOccurrences = symbolOccurrences.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var symbol in symbolOccurrences)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
