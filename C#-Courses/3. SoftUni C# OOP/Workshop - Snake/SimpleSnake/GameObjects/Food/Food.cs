
namespace SimpleSnake.GameObjects.Foods
{
using System;
using System.Collections.Generic;
using System.Linq;
   public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;
        private ConsoleColor color;

        protected Food(Wall wall, char foodSymbol, int points, ConsoleColor color)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
            this.color = color;

            this.FoodPoints = points;
        }

        public int FoodPoints { get; set; }

        public void SetRandomPositiob(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            bool isSnakeElement = snakeElements.Any(e => e.LeftX == this.LeftX && e.TopY == this.TopY);
            while (isSnakeElement)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isSnakeElement = snakeElements.Any(e => e.LeftX == this.LeftX && e.TopY == this.TopY);
            }

            Console.BackgroundColor = this.color;
            this.Draw(this.foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
            => snakeHead.LeftX == this.LeftX && snakeHead.TopY == this.TopY;
    }
}
