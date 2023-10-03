using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalSum = 0;
            while (command != "Start")
            {
                double coins = double.Parse(command);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    totalSum += coins;
                }
                else 
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                command = Console.ReadLine();
            }
            double Cost = 0;
            command = Console.ReadLine();

            while (command != "End")
            {
                switch (command)
                {
                    case "Nuts":
                    Cost = 2;
                        break;
                    case "Water":
                        Cost = 0.7;
                        break;
                    case "Crisps":
                        Cost = 1.5;
                        break;
                    case "Soda":
                        Cost = 0.8;
                        break;
                    case "Coke":
                        Cost = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        command = Console.ReadLine();
                        continue;
                }
                

                if (totalSum >= Cost)
                {
                    totalSum -= Cost;
                    Console.WriteLine($"Purchased {command.ToLower()}");
                    
                }
                else
                {
                   Console.WriteLine($"Sorry, not enough money");
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Change: {totalSum:f2}");

        }
    }
}
