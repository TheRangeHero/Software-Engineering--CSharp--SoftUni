
namespace Shapes
{
using System;
   public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(5, 6);
            Console.WriteLine(rectangle.Draw());

            Shape circle = new Circle(5);
            Console.WriteLine(circle.Draw());
        }
    }
}
