

namespace SimpleSnake.GameObjects.Foods
{
using System;
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int DefaulFoodPoints = 2;
        private const ConsoleColor DefaultColor = ConsoleColor.Green;
        public FoodDollar(Wall wall) 
            : base(wall, FoodSymbol, DefaulFoodPoints, DefaultColor)
        {
        }
    }
}
