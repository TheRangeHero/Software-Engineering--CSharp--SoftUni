using System;
using System.Collections;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expresion = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == '(')
                {
                    stack.Push(i);
                }


                if (expresion[i] == ')')
                {


                    int startindex = stack.Pop();

                    Console.WriteLine(expresion.Substring(startindex, i - startindex + 1));
                }


            }
        }
    }
}
