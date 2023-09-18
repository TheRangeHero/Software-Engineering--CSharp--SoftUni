using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._Energy_Drinks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] miligramsOfCaffeintInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int [] energtDrinkInputs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> miligramsOfCaffein = new Stack<int>(miligramsOfCaffeintInput);
            Queue<int> energyDrink = new Queue<int>(energtDrinkInputs);
            int caffeinLimit = 300;
            int currCaffeintTaken = 0;


            while (true)
            {

                if (!miligramsOfCaffein.Any() || !energyDrink.Any())
                {
                    break;
                }

                int currCaffeitMg = miligramsOfCaffein.Peek();
                int currDrink = energyDrink.Peek();
                int currCaffein = currCaffeitMg * currDrink;

                if (currCaffein+currCaffeintTaken<=caffeinLimit)
                {
                    currCaffeintTaken += currCaffein;
                   
                    energyDrink.Dequeue();
                    miligramsOfCaffein.Pop();
                }
                else
                {
                    miligramsOfCaffein.Pop();
                    energyDrink.Enqueue(energyDrink.Dequeue());
                    currCaffeintTaken -= 30;
                    if (currCaffeintTaken < 0)
                    {
                        currCaffeintTaken = 0;
                    }
                }

            }

            if (energyDrink.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ",energyDrink)}");
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {currCaffeintTaken} mg caffeine.");

        }
    }
}
