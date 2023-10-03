using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_Retake_Exam___13_April_2022___Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*salad soup salad steak
              2500 1800 1500
*/


            Dictionary<string, int> mealCalories = new Dictionary<string, int>
            {
                {"salad",350 },
                {"soup",490 },
                {"pasta",680 },
                {"steak",790 }
            };

            string[] mealsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] daysInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            Stack<int> days = new Stack<int>(daysInput);
            Queue<string> meals = new Queue<string>(mealsInput);

            int mealCounter = 0;


            while (true)
            {
                if (!days.Any() || !mealsInput.Any())
                {
                    break;
                }



                string currMeal = meals.Peek();
                int currDailyCalories = days.Peek();
                int leftCal = 0;
                while (meals.Any())
                {
                    currDailyCalories -= mealCalories[currMeal];
                    mealCounter++;

                    if (currDailyCalories<0)
                    {
                        leftCal = Math.Abs(currDailyCalories);
                        days.Pop();
                    }

                    meals.Dequeue();

                    if (meals.Any())
                    {
                    currMeal = meals.Peek();

                    }
                    else if (!meals.Any())
                    {
                        int leftCallSum = days.Pop();
                        leftCallSum -= leftCal;

                        days.Push(leftCallSum);
                        Console.WriteLine($"John had {mealCounter} meals.");
                        Console.WriteLine($"For the next few days, he can eat {string.Join(", ",days)} calories.");

                    }
                    
                    
                }

               


                






            }

        }
    }
}
