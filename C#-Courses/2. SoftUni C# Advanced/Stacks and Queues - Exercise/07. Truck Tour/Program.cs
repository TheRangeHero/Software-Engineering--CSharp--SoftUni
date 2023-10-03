using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpCount = int.Parse(Console.ReadLine());
            Queue<int> petrolAmount = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            for (int i = 0; i < pumpCount; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                petrolAmount.Enqueue(input[0]);
                distance.Enqueue(input[1]);
            }

            int fuel = petrolAmount.Peek();
            int smalletsIndex = 0;
            int currIndex = 0;
            int stationPassedCounter = 0;

            while (stationPassedCounter<=pumpCount)
            {
                if (stationPassedCounter == 0)
                {
                    smalletsIndex = currIndex;
                }

                if (fuel>=distance.Peek())
                {
                    fuel -= distance.Peek();
                    stationPassedCounter++;

                    petrolAmount.Enqueue(petrolAmount.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                    fuel += petrolAmount.Peek();

                }
                else
                {
                    petrolAmount.Enqueue(petrolAmount.Dequeue());
                    distance.Enqueue(distance.Dequeue());

                    fuel = petrolAmount.Peek();
                    stationPassedCounter = 0;
                }

                currIndex++;
            }
            Console.WriteLine(smalletsIndex);
        }
    }
}
