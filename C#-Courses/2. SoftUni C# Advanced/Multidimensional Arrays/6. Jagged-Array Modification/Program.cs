using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }


            string commands = Console.ReadLine().ToLower();

            while (commands != "end")
            {
                string[] splitted = commands.Split();
                int row = int.Parse(splitted[1]);
                int col = int.Parse(splitted[2]);
                int value = int.Parse(splitted[3]);

                if (!(row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length))
                {
                    Console.WriteLine("Invalid coordinates");
                    commands = Console.ReadLine().ToLower();
                    continue;
                }

                if (splitted[0] == "add")
                {
                    jaggedArray[row][col] += value;
                }
                else
                {
                    jaggedArray[row][col] -= value;
                }

                commands = Console.ReadLine().ToLower();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
