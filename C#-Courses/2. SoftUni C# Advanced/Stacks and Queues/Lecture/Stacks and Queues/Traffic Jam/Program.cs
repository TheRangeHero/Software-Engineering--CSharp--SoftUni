using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passNumber = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Queue<string> carList = new Queue<string>();

            int passedCarCount = 0;
            while (true)
            {

                if (input == "end")
                {
                    Console.WriteLine($"{passedCarCount} cars passed the crossroads.");
                    break;
                }

                if (input == "green")
                {
                    for (int i = 0; i < passNumber; i++)
                    {
                        if (carList.Count>0)
                        {
                        Console.WriteLine($"{carList.Dequeue()} passed!");
                        passedCarCount++;
                        }
                    }
                }
                else
                {
                    carList.Enqueue(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
