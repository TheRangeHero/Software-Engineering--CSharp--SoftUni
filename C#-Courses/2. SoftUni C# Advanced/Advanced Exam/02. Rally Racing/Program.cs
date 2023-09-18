using System;

namespace _02._Rally_Racing
{
    class Program
    {
        public static char[,] matrix;
        public static int carRow;
        public static int carCol;


        public static int firstTunelRow = -1;
        public static int firstTunelCol = -1;

        public static int secondTunelRow = -1;
        public static int secondTunelCol = -1;

        public static int finishRow = -1;
        public static int finishCol = -1;

        public static int kilometrs;
        public static bool carFinished = false;


        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();

            matrix = new char[sizes, sizes];

            for (int row = 0; row < sizes; row++)
            {
                string marixInput = Console.ReadLine().Replace(" ", string.Empty);
                for (int col = 0; col < sizes; col++)
                {
                    matrix[row, col] = marixInput[col];

                    if (matrix[row, col] == 'T')
                    {
                        if (firstTunelRow < 0 && firstTunelCol < 0)
                        {
                            firstTunelRow = row;
                            firstTunelCol = col;
                        }
                        else
                        {
                            secondTunelRow = row;
                            secondTunelCol = col;
                        }
                    }
                    else if (matrix[row, col] == 'F')
                    {
                        finishRow = row;
                        finishCol = col;
                    }
                }
            }




            carRow = 0;
            carCol = 0;

            string cmd;

            while ((cmd = Console.ReadLine()) != "End")
            {
                switch (cmd)
                {
                    case "up":
                        Move(-1, 0);
                       //PrintMatrix(sizes);
                        //Console.WriteLine(kilometrs);
                        //Console.WriteLine("--------------------------------------");
                        break;
                    case "down":
                        Move(1, 0);
                        //PrintMatrix(sizes);
                        //Console.WriteLine(kilometrs);
                        //Console.WriteLine("--------------------------------------");
                        break;
                    case "right":
                        Move(0, 1);
                        //PrintMatrix(sizes);
                        //Console.WriteLine(kilometrs);
                        //Console.WriteLine("--------------------------------------");
                        break;
                    case "left":
                        Move(0, -1);
                        //PrintMatrix(sizes);
                        //Console.WriteLine(kilometrs);
                        //Console.WriteLine("--------------------------------------");
                        break;
                }
                if (carFinished)
                {
                    break;
                }
            }

            if (carFinished)
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kilometrs} km.");

            PrintMatrix(sizes);

        }


        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void Move(int row, int col)
        {
            if (IsInMatrix(row + carRow, col + carCol))
            {
                if (matrix[carRow + row, carCol + col] == '.')
                {
                    matrix[carRow, carCol] = '.';
                    carRow += row;
                    carCol += col;
                    kilometrs += 10;
                }
                else if (matrix[carRow + row, carCol + col] == 'T')
                {
                    matrix[carRow, carCol] = '.';
                    carRow += row;
                    carCol += col;
                    if (carRow == firstTunelRow && carCol == firstTunelCol)
                    {
                        carRow = secondTunelRow;
                        carCol = secondTunelCol;
                        matrix[firstTunelRow, firstTunelCol] = '.';
                    }
                    else if (carRow == secondTunelRow && carCol == secondTunelCol)
                    {
                        carRow = firstTunelRow;
                        carCol = firstTunelCol;
                        matrix[secondTunelRow, secondTunelCol] = '.';
                    }
                    kilometrs += 30;
                }
                else if (matrix[carRow + row, carCol + col] == 'F')
                {
                    carFinished = true;
                    matrix[carRow, carCol] = '.';
                    carRow += row;
                    carCol += col;
                    kilometrs += 10;
                }
                matrix[carRow, carCol] = 'C';

            }
        }

        private static void PrintMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
