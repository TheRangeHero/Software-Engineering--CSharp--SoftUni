using System;
using System.Linq;
namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();

            SearchForVoweles(inputText);
        }

        private static void SearchForVoweles( string text)
        {
            
            //Console.WriteLine(text.Count(voweles=> "aouei".Contains(voweles)));

            int count = 0;
            foreach (char vowel in text)
            {
                if ("auoie".Contains(vowel))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
