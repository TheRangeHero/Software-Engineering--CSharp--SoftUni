
namespace SimpleSnake.GameObjects.Foods
{
using System;
    public class FoodAsterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int DefaulFoodPoints = 1;
        private const ConsoleColor DefaultColor = ConsoleColor.Red;
        public FoodAsterisk(Wall wall) 
            : base(wall, FoodSymbol, DefaulFoodPoints, DefaultColor)
        {
        }
    }
}
