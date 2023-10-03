using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int n1 = 0; n1 <= input; n1++)
            {
                for (int n2 = 0; n2 <= input; n2++)
                {
                    for (int n3 = 0; n3 <= input; n3++)
                    {
                        if (n1 + n2 + n3 == input)
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
