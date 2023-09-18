using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int subMatrixRows = 2;
            int subMatrixCols = 2;


            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputs[col];
                }
            }

            int maxSum = 0;
            int squareStartRow = 0;
            int squareStartCol = 0;
            for (int row = 0; row < rows - subMatrixRows + 1; row++)
            {
                for (int col = 0; col < cols - subMatrixCols + 1; col++)
                {
                    int sum = 0;


                    for (int subRow = 0; subRow < subMatrixRows; subRow++)
                    {
                        for (int subCol = 0; subCol < subMatrixCols; subCol++)
                        {
                            sum += matrix[row + subRow, col + subCol];
                        }
                    }

                    //sum += matrix[row, col];     -----------
                    //sum += matrix[row + 1, col];            |
                    //sum += matrix[row, col + 1];            | ---> static for 2x2 cheking Square
                    //sum += matrix[row + 1, col + 1];        |
                    //                              ----------

                    if (sum > maxSum)
                    {
                        squareStartRow = row;
                        squareStartCol = col;


                        maxSum = sum;
                    }
                }
            }


            for (int subRow = 0; subRow < subMatrixRows; subRow++)
            {
                for (int subCol = 0; subCol < subMatrixCols; subCol++)
                {
                    Console.Write($"{matrix[squareStartRow + subRow, squareStartCol + subCol]} ");
                }
                Console.WriteLine();
            }


            //Console.WriteLine($"{matrix[squareStartRow,squareStartCol]} {matrix[squareStartRow,squareStartCol+1]}"); ------------
            //Console.WriteLine($"{matrix[squareStartRow+1,squareStartCol]} {matrix[squareStartRow+1,squareStartCol+1]}");         | ----> Static for 2x2 cheking Square
            //                                                                                                           -----------
            Console.WriteLine(maxSum);

        }
    }
}
