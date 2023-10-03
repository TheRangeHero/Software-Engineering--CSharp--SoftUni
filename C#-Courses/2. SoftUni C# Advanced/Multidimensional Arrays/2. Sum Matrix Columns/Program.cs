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
            int cols = sizes[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int columnSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    columnSum += matrix[row, col];
                }
                Console.WriteLine(columnSum);
            }

        }
    }
}
