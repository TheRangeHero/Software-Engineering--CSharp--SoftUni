using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string[], string> addTitle = (name, title) =>
             {
                 foreach (string item in name)
                 {
                     Console.WriteLine($"{title} {item}");
                 }
             };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            addTitle(names, "Sir");
        }
    }
}
