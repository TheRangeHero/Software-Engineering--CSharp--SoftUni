namespace SimpleSnake.GameObjects.Foods
{
using System;
  public  class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int DefaulFoodPoints = 2;
        private const ConsoleColor DefaultColor = ConsoleColor.DarkYellow;
        public FoodHash(Wall wall) 
            : base(wall, FoodSymbol, DefaulFoodPoints, DefaultColor)
        {
        }
    }
}
