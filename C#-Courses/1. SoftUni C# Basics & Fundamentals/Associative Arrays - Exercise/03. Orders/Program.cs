using System;
using System.Collections.Generic;

namespace _03._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> priceByProduct = new Dictionary<string, double>();
            Dictionary<string, int> quantityByProduct = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "buy")
            {

                string [] cmd = input.Split();
                string productName = cmd[0];

                double productPrice = double.Parse(cmd[1]);
                int productQuantity = int.Parse(cmd[2]);


                if (!priceByProduct.ContainsKey(productName))
                {
                    priceByProduct.Add(productName, productPrice);
                    quantityByProduct.Add(productName, productQuantity); 
                }
                else if (priceByProduct.ContainsKey(productName))
                {
                    priceByProduct.Remove(productName);
                    priceByProduct.Add(productName, productPrice);

                    quantityByProduct[productName] += productQuantity;
                }
                input = Console.ReadLine();
            }

            foreach (var order in priceByProduct)
            {
                foreach (var newOrder in quantityByProduct)
                {
                    if (order.Key == newOrder.Key)
                    {
                        Console.WriteLine($"{order.Key} -> {(order.Value*newOrder.Value):f2}");
                    }
                }
            }
        }
    }
}
