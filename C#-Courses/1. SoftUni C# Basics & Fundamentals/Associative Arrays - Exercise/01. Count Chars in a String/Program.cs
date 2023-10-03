using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] word = Console.ReadLine().ToCharArray();

            Dictionary<char, int> countByChar = new Dictionary<char, int>();

            foreach (var letter in word)
            {
                if (letter != ' ')
                {
                    if (!countByChar.ContainsKey(letter))
                    {
                        countByChar[letter] = 0;
                    }
                    countByChar[letter]++;
                }
            }

            foreach (var kvpChar in countByChar)
            {
                Console.WriteLine($"{kvpChar.Key} -> {kvpChar.Value}");
            }
        }
    }
}
