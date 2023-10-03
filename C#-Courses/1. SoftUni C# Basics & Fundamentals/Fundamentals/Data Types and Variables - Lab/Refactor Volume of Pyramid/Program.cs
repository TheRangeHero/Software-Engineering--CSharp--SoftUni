using System;

namespace Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double Length = double.Parse(Console.ReadLine());
            Console.Write("Length: ");

            double Width = double.Parse(Console.ReadLine());
            Console.Write("Width: ");

            double Height = double.Parse(Console.ReadLine());
            Console.Write("Height: ");           

            double pyramidVolume = (Length * Width * Height) / 3;

            Console.WriteLine($"Pyramid Volume: {pyramidVolume:f2}");
        }
    }
}
