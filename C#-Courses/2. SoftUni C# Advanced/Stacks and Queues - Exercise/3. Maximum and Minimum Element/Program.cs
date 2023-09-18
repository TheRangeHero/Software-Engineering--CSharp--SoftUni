using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input; i++)
            {

                int[] cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int command = cmds[0];

                switch (command)
                {
                    case 1:
                        stack.Push(cmds[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine($"{stack.Max()}");
                        };
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine($"{stack.Min()}");
                        };
                        break;
                }


            }
                Console.WriteLine(string.Join(", ",stack));

        }
    }
}
