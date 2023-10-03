using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            int cmdPush = cmds[0];
            int cmdPop = cmds[1];
            int cmdCheck = cmds[2];


            for (int i = 0; i < cmdPush; i++)
            {
                stack.Push(inputs[i]);
            }

            for (int i = 0; i < cmdPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(cmdCheck))
            {
                Console.WriteLine("true");
            }
            else
            {

                if (stack.Count > 0)
                {
                    Console.WriteLine($"{stack.Min()}");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }


        }
    }
}
