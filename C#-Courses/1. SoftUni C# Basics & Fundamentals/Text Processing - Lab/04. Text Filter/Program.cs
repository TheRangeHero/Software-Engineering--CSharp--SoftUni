using System;

namespace _5._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {

                string replaceWithAsterisks = new string('*', bannedWord.Length);
                text = text.Replace(bannedWord, replaceWithAsterisks);
            }

            Console.WriteLine(text);
        }
    }
}
