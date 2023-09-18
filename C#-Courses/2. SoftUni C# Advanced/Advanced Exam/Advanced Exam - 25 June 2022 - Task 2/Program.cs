using System;

namespace Advanced_Exam___25_June_2022___Task_2
{
    class Program
    {
        public static char[,] matrix;
        public static int vankoRowPosition = 0;
        public static int vankoColPosition = 0;
        public static bool isVankoElectrecuted = false;
        public static int holeCounter = 1;
        public static int rodCounter;
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            matrix = new char[sizes, sizes];
            //marix initialize
            for (int row = 0; row < sizes; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < sizes; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            //Vanko position
            for (int row = 0; row < sizes; row++)
            {
                
                for (int col = 0; col < sizes; col++)
                {
                    if (matrix[row,col] == 'V')
                    {
                        vankoRowPosition = row;
                        vankoColPosition = col;
                    }
                }
            }



            string cmd;
            while ((cmd=Console.ReadLine())!="End")
            {

                switch (cmd)
                {
                    case "up":
                        Move(-1,0);
                        //PrintMatrix(sizes);
                        //Console.WriteLine();
                        //Console.WriteLine();
                        break;
                    case "down":
                        Move(1,0);
                        //PrintMatrix(sizes);
                        //Console.WriteLine();
                        //Console.WriteLine();
                        break;
                    case "left":
                        Move(0,-1);
                        //PrintMatrix(sizes);
                        //Console.WriteLine();
                        //Console.WriteLine();
                        break;
                    case "right":
                        Move(0,1);
                        //PrintMatrix(sizes);
                        //Console.WriteLine();
                        //Console.WriteLine();
                        break;
                }

                if (isVankoElectrecuted)
                {
                    break;
                }
            }

            if (!isVankoElectrecuted)
            {
                Console.WriteLine($"Vanko managed to make {holeCounter} hole(s) and he hit only {rodCounter} rod(s).");
            }
            PrintMatrix(sizes);
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void Move(int row, int col)
        {
            if (IsInMatrix(row+vankoRowPosition,col+vankoColPosition))
            {
                if (matrix[row + vankoRowPosition, col + vankoColPosition]=='-')
                {
                    matrix[vankoRowPosition, vankoColPosition] = '*';
                    vankoRowPosition += row;
                    vankoColPosition += col;
                    holeCounter++;
                    matrix[vankoRowPosition, vankoColPosition] = 'V';
                }
                else if (matrix[row + vankoRowPosition, col + vankoColPosition] == '*')
                {
                    matrix[vankoRowPosition, vankoColPosition] = '*';
                    vankoRowPosition += row;
                    vankoColPosition += col;
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRowPosition}, {vankoColPosition}]!");
                    matrix[vankoRowPosition, vankoColPosition] = 'V';
                }
                else if (matrix[row + vankoRowPosition, col + vankoColPosition] == 'R')
                {
                    rodCounter++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[row + vankoRowPosition, col + vankoColPosition] == 'C')
                {
                    matrix[vankoRowPosition, vankoColPosition] = '*';
                    vankoRowPosition += row;
                    vankoColPosition += col;
                    holeCounter++;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
                    matrix[vankoRowPosition, vankoColPosition] = 'E';
                    isVankoElectrecuted = true;
                }
            }
        }

        public static void PrintMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {               

                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
