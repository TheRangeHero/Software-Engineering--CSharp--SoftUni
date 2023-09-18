using System;

namespace DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Array.Empty<int>();
            Console.WriteLine(array.Length);
            array[1] = 123;
            
            Console.WriteLine(array[1]);
        }
    }
}
