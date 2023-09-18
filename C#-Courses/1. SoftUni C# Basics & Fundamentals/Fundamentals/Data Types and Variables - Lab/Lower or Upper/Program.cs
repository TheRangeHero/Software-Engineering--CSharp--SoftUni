using System;

namespace Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char n = char.Parse(Console.ReadLine());

            if (char.IsUpper(n))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
