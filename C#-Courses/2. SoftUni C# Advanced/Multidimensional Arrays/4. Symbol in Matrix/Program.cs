using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            int rows = sizes;
            int cols = sizes;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isSymbolMatched = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isSymbolMatched = true;
                        break;
                    }
                }
                if (isSymbolMatched == true)
                {
                    break;
                }
            }

            if (isSymbolMatched == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
