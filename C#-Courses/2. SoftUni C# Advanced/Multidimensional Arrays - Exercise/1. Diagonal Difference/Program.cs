using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            int rows = sizes;
            int cols = sizes;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputs = Console.ReadLine().Split().Select(n=>int.Parse(n)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputs[col];
                }
            }

            int rightToLeftDiagonal = 0;
            int leftToRightDiagonal = 0;
            for (int row = 0,col=matrix.GetLength(1)-1; row < matrix.GetLength(0); row++,col--)
            {
                rightToLeftDiagonal += matrix[row, row];
                leftToRightDiagonal += matrix[col, row];
            }


            //for (int row = 0, col = 0; row < matrix.GetLength(0); row++, col++)
            //{
            //    rightToLeftDiagonal += matrix[row, col];
            //}

            //for (int row = 0, col = matrix.GetLength(1) - 1; row < matrix.GetLength(0); row++, col--)
            //{
            //    leftToRightDiagonal += matrix[row, col];
            //}


            Console.WriteLine($"{Math.Abs(rightToLeftDiagonal-leftToRightDiagonal)}");
        }
    }
}
