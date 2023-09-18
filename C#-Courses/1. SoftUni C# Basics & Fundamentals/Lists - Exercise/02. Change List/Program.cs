using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {

                string[] tokens = command.Split();

                /*if (tokens[0] == "Delete")
                {
                    numbers.RemoveAll(element => element == int.Parse(tokens[1]));
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else if (tokens[0] == "Insert")
                {
                    numbers.Insert(int.Parse(tokens[2]), int.Parse(tokens[1]));
                }*/

              switch (tokens[0])
                {
                    case "Delete":
                        DeleteEqualElements(numbers,  tokens[0],int.Parse(tokens[1]));
                        break;
                    case "Insert":
                        InsertElement(numbers, tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                        
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }


         static List<int> DeleteEqualElements(List<int> numbers, string command, int index)
        {
            /*for (int i = 0; i <numbers.Count; i++)
            {
                int currElement = numbers[i];
                if (currElement==index)
                {
                    numbers.Remove(index);
                    i--;                    
                }
            }*/

            numbers.RemoveAll(element => element == index);
            return numbers;

        }

         static List<int> InsertElement(List<int> numbers, string command, int element, int position)
        {
            numbers.Insert(position, element);

            return numbers;
        }
    }
}
