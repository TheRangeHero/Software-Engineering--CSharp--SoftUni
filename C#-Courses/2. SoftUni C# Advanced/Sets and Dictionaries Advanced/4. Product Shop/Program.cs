using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>();


            while (command != "Revision")
            {
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string storeName = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!stores.ContainsKey(storeName))
                {
                    stores.Add(storeName, new Dictionary<string, double>());
                }

                stores[storeName].Add(product,price);

                 command = Console.ReadLine();
            }


            stores = stores.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var store in stores)
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {(product.Value)}");
                }
            }
        }
    }
}
