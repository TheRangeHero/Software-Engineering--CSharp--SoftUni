using System;
using System.Collections.Generic;

namespace Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> answer = new Stack<char>();

            foreach (var charr in input)
            {
                answer.Push(charr);
            }

            while (answer.Count>0)
            {
                Console.Write(answer.Pop());
            }
        }
    }
}
