using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 2)
                {
                    /*int wagon = int.Parse(tokens[1]);
                    wagons.Add(wagon);*/
                    wagons.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int passangers = int.Parse(tokens[0]);

                    FindWagon(wagons, maxCapacity, passangers);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));

        }

        private static void FindWagon(List<int> wagons, int maxCapacity, int passangers)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currentWagon = wagons[i];
                if (currentWagon + passangers <= maxCapacity)
                {
                    wagons[i] += passangers;
                    break;
                }
            }
        }
    }
}
