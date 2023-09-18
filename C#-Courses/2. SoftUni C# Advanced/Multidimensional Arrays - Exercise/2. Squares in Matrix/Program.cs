using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                char[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => char.Parse(n)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputs[col];
                }
            }

            int count = 0;

            //if (matrix.GetLength(0) > 1 && matrix.GetLength(1) > 1)
            //{
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        if (matrix[row, col] == matrix[row, col + 1]
                            && matrix[row, col] == matrix[row + 1, col + 1]
                            && matrix[row, col] == matrix[row + 1, col])
                        {
                            count++;
                        }
                    }
                }

                Console.WriteLine(count);
            //}

            //else
            //{
            //    Console.WriteLine(1);
            //}
        }
    }
}
