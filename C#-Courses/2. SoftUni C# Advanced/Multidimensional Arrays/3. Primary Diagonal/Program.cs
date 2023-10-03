using System;
using System.Linq;

namespace matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            int rows = sizes;
            int cols = sizes;
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int diagonalSum = 0;
            for (int row = 0, col = 0; row < matrix.GetLength(0); row++, col++)
            {
                diagonalSum += matrix[row, col];
            }
            Console.WriteLine(diagonalSum);
        }
    }
}
