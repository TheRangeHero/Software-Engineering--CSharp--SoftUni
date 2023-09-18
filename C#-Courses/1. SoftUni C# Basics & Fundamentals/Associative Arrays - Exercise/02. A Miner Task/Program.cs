using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            string resources = Console.ReadLine();

            while (resources != "stop")
            {
                //if (resources!=null)
                //{

                int quantity = int.Parse(Console.ReadLine());

                if (!items.ContainsKey(resources))
                {
                    items.Add(resources, 0);
                }
                items[resources] += quantity;


                resources = Console.ReadLine();
                //}
            }

            foreach (var currResources in items)
            {
                Console.WriteLine($"{currResources.Key} -> {currResources.Value}");
            }
        }
    }
}
