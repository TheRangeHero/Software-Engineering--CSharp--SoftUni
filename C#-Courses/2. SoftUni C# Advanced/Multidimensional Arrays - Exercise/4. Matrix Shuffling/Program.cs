using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputs[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }



                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (IsValidCommand(sizes, tokens))
                {
                    int tempRow = int.Parse(tokens[1]);
                    int tempCol = int.Parse(tokens[2]);
                    int newRow = int.Parse(tokens[3]);
                    int newCol = int.Parse(tokens[4]);
                    string tempValue = matrix[tempRow, tempCol]; //Hello
                    matrix[tempRow, tempCol] = matrix[newRow, newCol]; // Hello -> World
                    matrix[newRow, newCol] = tempValue; // World -> Hello


                    PrintMatrix(matrix);

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
        }

         static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValidCommand(int[] sizes, string[] tokens)
        {
            bool isValidCommand =
                    tokens[0] == "swap"
                    && tokens.Length == 5
                    && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < sizes[0]
                    && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < sizes[1]
                    && int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < sizes[0]
                    && int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < sizes[1];

            return isValidCommand;
        }
    }
}
