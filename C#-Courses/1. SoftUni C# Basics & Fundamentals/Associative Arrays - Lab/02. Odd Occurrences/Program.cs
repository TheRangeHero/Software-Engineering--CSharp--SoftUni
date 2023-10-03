using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> countByWords = new Dictionary<string, int>();
            string[] words = Console.ReadLine().Split().Select(word => word.ToLower()).ToArray();

            foreach (var word in words)
            {
                if (!countByWords.ContainsKey(word))
                {
                    countByWords.Add(word, 0);
                }
                countByWords[word]++;
            }

            string[] oddWordsCount = countByWords.Where(word => word.Value % 2 != 0).Select(word => word.Key).ToArray();

            Console.WriteLine(string.Join(" ", oddWordsCount));
        }
    }
}
