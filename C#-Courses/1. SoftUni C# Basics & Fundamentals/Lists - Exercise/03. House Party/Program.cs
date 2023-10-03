using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();


            for (int i = 0; i < numberOfCommands; i++)
            {
               
                
                
                string[] command = Console.ReadLine().Split();

                string currName = command[0];

                if (guests.Contains(currName) && command[2] == "going!")
                {
                    Console.WriteLine($"{currName} is already in the list!");
                }
                else if (guests.Contains(currName) && command[2] == "not")
                {
                    guests.Remove(currName);  
                }
                else if (!guests.Contains(currName) && command[2] == "not")
                {
                    Console.WriteLine($"{currName} is not in the list!");
                }
                else 
                {
                    guests.Add(currName);
                }
            }
            foreach (string name in guests)
            {
                Console.WriteLine(name);
            }
        }
    }
}
