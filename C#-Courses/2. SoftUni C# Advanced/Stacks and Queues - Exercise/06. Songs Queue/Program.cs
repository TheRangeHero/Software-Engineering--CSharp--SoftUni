using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> songsName = new List<string>(Console.ReadLine().Split(", "));

            Queue<string> songsQueue = new Queue<string>(songsName);

            while (songsQueue.Count > 0)
            {
                string[] cmds = Console.ReadLine().Split();


                switch (cmds[0])
                {
                    case "Add":
                        string songToAdd = String.Join(" ", cmds.Skip(1));
                        if (songsQueue.Contains(songToAdd))
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                            continue;
                        }
                        songsQueue.Enqueue(songToAdd);
                        break;
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", songsQueue));
                        break;
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
