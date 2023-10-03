using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<int> number = new Box<int>();

            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());

                number.IntCollection.Add(input);
            }

            Console.WriteLine(number.ToString());
        }
    }
}
