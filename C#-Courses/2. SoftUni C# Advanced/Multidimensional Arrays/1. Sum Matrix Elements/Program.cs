using System;
using System.Linq;

namespace matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int columns = sizes[1];
            int matrixElementsSum = 0;

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = colElements[col];
                }

            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrixElementsSum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(matrixElementsSum);

        }
    }
}
