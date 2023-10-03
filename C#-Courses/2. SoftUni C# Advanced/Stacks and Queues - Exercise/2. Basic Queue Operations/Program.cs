using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cmds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbersToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            int enqueueCMD = cmds[0];
            int dequeueCMD = cmds[1];
            int checkCMD = cmds[2];

            for (int i = 0; i < enqueueCMD; i++)
            {
                queue.Enqueue(numbersToAdd[i]);
            }

            for (int i = 0; i < dequeueCMD; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(checkCMD))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine($"{queue.Min()}");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }

        }
    }
}
