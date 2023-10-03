using System;

namespace Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int n1 = 1; n1 < 11; n1++)
            {
                for (int n2 = 1; n2 < 11; n2++)
                {
                    Console.WriteLine($"{n1} * {n2} = {n1 * n2}");
                }
            }
        }
    }
}
