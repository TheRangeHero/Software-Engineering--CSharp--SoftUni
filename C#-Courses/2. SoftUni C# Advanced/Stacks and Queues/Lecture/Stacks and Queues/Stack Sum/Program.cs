using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            string input = Console.ReadLine().ToLower();


            while (true)
            {
                var splitted = input.Split();
                string command = splitted[0];
                if (command == "end")
                {
                    break;
                }


                switch (command)
                {
                    case "add":
                        int numberOne = int.Parse(splitted[1]);
                        int numberTwo = int.Parse(splitted[2]);

                        numbers.Push(numberOne);
                        numbers.Push(numberTwo);
                        break;

                    case "remove":
                        int count = int.Parse(splitted[1]);
                        if (numbers.Count >= count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;
                }

                input = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {numbers.Sum()}");

        }
    }
}
