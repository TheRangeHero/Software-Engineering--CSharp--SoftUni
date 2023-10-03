using System;

namespace Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int vowels = 0;
            for (int i = 0; i<text.Length;i++)
            {
                char letter = text[i];
                switch (letter)
                {
                    case 'a':
                        vowels += 1;
                        break;
                    case 'e':
                        vowels += 2;
                        break;
                        case 'i':
                        vowels += 3;
                        break;
                    case 'o':
                        vowels += 4;
                        break;
                    case 'u':
                        vowels += 5;
                        break;
                }
            }
            Console.WriteLine(vowels);
        }
    }
}
