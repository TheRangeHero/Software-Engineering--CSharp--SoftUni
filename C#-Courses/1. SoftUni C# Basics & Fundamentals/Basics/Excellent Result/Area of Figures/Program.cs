using System;

namespace AreaОfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            double S = 0;

            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());

                S = a * a;
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                S = a * b;
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double Pi = Math.PI;
                double squareR = Math.Pow(r, 2);

                S = Pi * squareR;
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                S = a * h / 2;
            }

            Console.WriteLine($"{S:f3}");
        }
    }
}
