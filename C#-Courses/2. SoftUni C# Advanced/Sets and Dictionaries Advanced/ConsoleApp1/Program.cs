using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = tokens[0];
                string carNumber = tokens[1];


                if (cmd == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }
                input = Console.ReadLine();
            }

            if (!carNumbers.Any())
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {

                foreach (var carNumber in carNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
