using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(ordersInput);
            Console.WriteLine($"{orders.Max()}");


            while (orders.Count>0)
            {
                if (foodQuantity>=orders.Peek())
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }
            if (orders.Count == 0)
            {

            Console.WriteLine("Orders complete");               
            }
            
        }
    }
}
