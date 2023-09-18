using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>(Console.ReadLine().Split());
            int turns = int.Parse(Console.ReadLine());
            while (names.Count>1)
            {
                for (int i = 1; i <turns; i++)
                {
                    string backInQueue =names.Dequeue();
                    names.Enqueue(backInQueue);
                }

                Console.WriteLine($"Removed {names.Dequeue()}");
            }

            Console.WriteLine($"Last is {names.Peek()}");
        }
    }
}
