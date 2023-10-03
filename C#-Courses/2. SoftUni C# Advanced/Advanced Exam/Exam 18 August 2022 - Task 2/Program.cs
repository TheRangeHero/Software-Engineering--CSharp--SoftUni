using System;
using System.Linq;

namespace Exam_18_August_2022___Task_2
{
    class Program
    {
            public static int molePositionRow = -1;
           public static  int molePositionCol = -1;
            public static int points = 0;

            public static int firstSpecialPointRow = -1;
            public static int firstSpecialPointCol = -1;
            public static int secondSpecialPointRow = -1;
            public static int secondSpecialPointCol = -1;



            public static char[,] matrix;
        static void Main(string[] args)
        {

            int sizes = int.Parse(Console.ReadLine());

            matrix = new char[sizes, sizes];

            //matrix initialization
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            //mole position
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        molePositionRow = row;
                        molePositionCol = col;
                        break;
                    }
                }
            }



            //special point positions

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        if (firstSpecialPointRow < 0 && firstSpecialPointCol < 0)
                        {
                            firstSpecialPointRow = row;
                            firstSpecialPointCol = col;
                        }
                        else
                        {
                            secondSpecialPointRow = row;
                            secondSpecialPointCol = col;
                        }
                    }
                }
            }

            //receiving directions
            string cmd;
            while ((cmd=Console.ReadLine())!="End"&&points<25)
            {
                switch (cmd)
                {
                    case "up":
                        Move( -1, 0);
                        break;
                    case "down":
                        Move( 1, 0);
                        break;
                    case "left":
                        Move( 0, -1);
                        break;
                    case "right":
                        Move( 0, 1);
                        break;
                }
            }

            if (points<25)
            {
                Console.WriteLine($"Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            else
            {
                Console.WriteLine($"Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }

            PrintMatrix( sizes);






           
        }


        private static bool IsInMatrix( int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void Move( int row, int col)
        {
            if (IsInMatrix( row + molePositionRow, col + molePositionCol))
            {
                if (matrix[molePositionRow + row, molePositionCol + col] == '-')
                {
                    matrix[molePositionRow, molePositionCol] = '-';
                    molePositionRow += row;
                    molePositionCol += col;
                }
                else if (char.IsDigit(matrix[molePositionRow + row, molePositionCol + col]))
                {
                    matrix[molePositionRow, molePositionCol] = '-';
                    molePositionRow += row;
                    molePositionCol += col;
                    points += int.Parse(matrix[molePositionRow, molePositionCol].ToString());
                    matrix[molePositionRow, molePositionCol] = 'M';
                }
                else if (matrix[molePositionRow + row, molePositionCol + col] == 'S')
                {
                    matrix[molePositionRow, molePositionCol] = '-';
                    molePositionRow += row;
                    molePositionCol += col;
                    if (molePositionRow == firstSpecialPointRow && molePositionCol == firstSpecialPointCol)
                    {
                        molePositionRow = secondSpecialPointRow;
                        molePositionCol = secondSpecialPointCol;
                        matrix[firstSpecialPointRow, firstSpecialPointCol] = '-';
                    }
                    else if (molePositionRow == secondSpecialPointRow && molePositionCol == secondSpecialPointCol)
                    {
                        molePositionRow = firstSpecialPointRow;
                        molePositionCol = firstSpecialPointCol;
                        matrix[secondSpecialPointRow, secondSpecialPointCol] = '-';
                    }
                    points -= 3;
                }
                matrix[molePositionRow, molePositionCol] = 'M';

                
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
            }
            
        }

        private static void PrintMatrix( int n)
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
