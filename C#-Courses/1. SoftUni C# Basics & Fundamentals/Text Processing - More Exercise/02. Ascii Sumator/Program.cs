using System;
using System.Linq;
using System.Text;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
             firstChar = ++firstChar;
           
            string input = Console.ReadLine();
            
            int sum = 0;

            for (char ch = firstChar; ch < secondChar; ch++)
            {
                foreach (char c in input)
                {
                    if (c == ch)
                        sum += (int)ch;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
