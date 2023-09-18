using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_18_August_2022___Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>();
            Stack<int> milk = new Stack<int>();
            Dictionary<string, int> drinksCount = new Dictionary<string, int>();


            Dictionary<string, int> drinkList = new Dictionary<string, int>()
            {
                { "Cortado",50 },
                { "Espresso",75 },
                { "Capuccino",100 },
                { "Americano",150},
                { "Latte",200 },
            };
            bool isDrinkMade = false;
            int[] coffeQueueInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] milkStackInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < coffeQueueInput.Length; i++)
            {
                coffee.Enqueue(coffeQueueInput[i]);
            }
            
            for (int i = 0; i < milkStackInput.Length; i++)
            {
                milk.Push(milkStackInput[i]);
            }



            while (true)
            {
                if (!coffee.Any() || !milk.Any())
                {
                    break;
                }

                isDrinkMade = false;

                int currentCoffee = coffee.Peek();
                int currentMilk = milk.Peek();
                int sumMilkCoffee = currentCoffee + currentMilk;


                foreach (var drink in drinkList)
                {
                    if (drink.Value==sumMilkCoffee)
                    {
                        if (!drinksCount.ContainsKey(drink.Key))
                        {
                            drinksCount.Add(drink.Key, 1);
                        }
                        else
                        {
                            drinksCount[drink.Key]++;
                        }
                        milk.Pop();
                        coffee.Dequeue();
                        isDrinkMade = true;
                        break;

                    }
                }

                if (!isDrinkMade)
                {
                    if (coffee.Any())
                    {
                        coffee.Dequeue();
                    }
                    if (milk.Any())
                    {
                        milk.Push(milk.Pop() - 5);
                    }
                }


            }


            if (milk.Count==0 && coffee.Count()==0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }





            if (coffee.Count()==0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }

            if (milk.Count() == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }


            

            foreach (var item in drinksCount.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key))
            {
                

                    Console.WriteLine($"{item.Key}: {item.Value}");
                
            }
        }
    }
}
