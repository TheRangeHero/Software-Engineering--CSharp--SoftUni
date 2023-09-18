using System;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<string> stringList = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                stringList.ListToCompare.Add(input);
            }

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(stringList.Count(itemToCompare));
        }
    }
}
