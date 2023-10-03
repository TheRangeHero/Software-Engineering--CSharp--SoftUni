using System;
using System.Collections;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<string> queue = new Queue<string>();

            while (true)
            {

                if (input == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }

                if (input == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();

            }

        }
    }
}
