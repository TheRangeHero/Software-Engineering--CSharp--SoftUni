using System;
using System.Collections.Generic;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expressions = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(Console.ReadLine().Split());


            for (int i = 0; i < expressions.Length; i++)
            {
                stack.Push(expressions[i]);


                if (stack.Count==3)
                {
                    int first = int.Parse(stack.Pop());
                    var sign = stack.Pop();
                    int second = int.Parse(stack.Pop());
                    int result = 0;

                    if (sign =="+")
                    {
                        result = first + second;
                    }

                    if (sign == "-")
                    {
                        result = second - first;
                    }

                    stack.Push(result.ToString());
                }
            }

            Console.WriteLine(stack.Pop());
            

        }
    }
}
