using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isListChanged = false;
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split();


                switch (tokens[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(tokens[1]));
                        isListChanged = true;
                        break;

                    case "Remove":
                        numbers.Remove(int.Parse(tokens[1]));
                        isListChanged = true;
                        break;

                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(tokens[1]));
                        isListChanged = true;
                        break;

                    case "Insert":
                        numbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                        isListChanged = true;
                        break;


                    case "Contains":
                        PrintContains(numbers, tokens);
                        break;
                    case "PrintEven":
                        PrintAllEvenNumber(numbers);
                        break;
                    case "PrintOdd":
                        PrintAllOddNumbers(numbers);
                        break;
                    case "GetSum":
                        SumAllNumbers(numbers);
                        break;
                    case "Filter":
                        PrintFilteredNumbers(numbers, tokens);
                        break;
                }


                input = Console.ReadLine();
            }
            if (isListChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }


        static void PrintContains(List<int> number, string[] tokens)
        {
            if (number.Contains(int.Parse(tokens[1])))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }

        }


        static void PrintAllEvenNumber(List<int> numbers)
        {
            List<int> evenNums = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNums.Add(number);
                }

            }
            Console.WriteLine(string.Join(" ", evenNums));
        }

        static void PrintAllOddNumbers(List<int> numbers)
        {
            List<int> oddNums = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    oddNums.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", oddNums));
        }

        static void SumAllNumbers(List<int> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }

        static void PrintFilteredNumbers(List<int> numbers, string[] tokens)
        {
            List<int> filteredNums = new List<int>();
            switch (tokens[1])
            {
                case "<":
                    foreach (int number in numbers)
                    {
                        if (number < int.Parse(tokens[2]))
                        {

                            filteredNums.Add(number);
                        }
                    }

                    break;
                case "<=":
                    foreach (int number in numbers)
                    {
                        if (number <= int.Parse(tokens[2]))
                        {

                            filteredNums.Add(number);
                        }
                    }

                    break;
                case ">":
                    foreach (int number in numbers)
                    {
                        if (number > int.Parse(tokens[2]))
                        {

                            filteredNums.Add(number);
                        }
                    }

                    break;
                case ">=":
                    foreach (int number in numbers)
                    {
                        if (number >= int.Parse(tokens[2]))
                        {

                            filteredNums.Add(number);
                        }
                    }

                    break;
            }
            Console.WriteLine(string.Join(" ", filteredNums));

        }
    }
}
