using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core
{
using SimpleSnake.Core.Contracts;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
    using System.Threading;

    class Engine : IEngine
    {
        private const double DefaulSleepTime = 100;

        private readonly Point[] directionPoints;
        private Direction direction;
        private readonly Snake snake;
        private readonly Wall wall;
        private double sleepTime;
        private double difficultyStep=0.01;


        private Engine()
        {
            this.directionPoints = new Point[4];
            this.sleepTime = DefaulSleepTime;
        }
        public Engine(Wall wall, Snake snake):this()
        {
            this.wall = wall;
            this.snake = snake;
        }

        public void Run()
        {
            this.GetDirectionPoints();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool canMove = snake.CanMove(this.directionPoints[(int)this.direction]);
                if (!canMove)
                {

                }

                this.sleepTime -= difficultyStep;
                Thread.Sleep((int)this.sleepTime);
            }
        }


        private void GetDirectionPoints()
        {
            this.directionPoints[(int)Direction.Right] = new Point(1, 0);
            this.directionPoints[(int)Direction.Left] = new Point(-1, 0);
            this.directionPoints[(int)Direction.Down] = new Point(0, 1);
            this.directionPoints[(int)Direction.Up] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key==ConsoleKey.LeftArrow)
            {
                if (this.direction!=Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key==ConsoleKey.RightArrow)
            {
                if (this.direction!=Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction !=Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction !=Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue?  y/n");

            string answer = Console.ReadLine();
            if (answer.ToLower()=="y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {

            }
        }

        private void Stopgame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Environment.Exit(0);
        }
    }
}
