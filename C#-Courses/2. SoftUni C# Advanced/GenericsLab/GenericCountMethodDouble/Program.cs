using System;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.box.Add(input);
            }

            double itemToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Count(itemToCompare));
        }
    }
}
