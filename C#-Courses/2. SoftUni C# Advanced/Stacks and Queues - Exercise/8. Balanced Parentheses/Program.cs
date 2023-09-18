using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            Stack<char> sequence = new Stack<char>();

            foreach (var symbol in input)
            {
                if (sequence.Any())
                {
                    char check = sequence.Peek();

                    if (check == '(' && symbol == ')')
                    {
                        sequence.Pop();
                        continue;
                    }
                    else if (check == '{' && symbol == '}')
                    {
                        sequence.Pop();
                        continue;
                    }
                    else if (check == '[' && symbol == ']')
                    {
                        sequence.Pop();
                        continue;
                    }
                }

                sequence.Push(symbol);

            }
            //Console.WriteLine(!sequence.Any() ? "YES" : "NO");
            if (sequence.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
