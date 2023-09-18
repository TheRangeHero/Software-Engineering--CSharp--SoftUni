using System;

namespace GenericArrayCreator
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = ArrayCreator.Create(10, 42);
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
