using System;

namespace Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            bool isNumberEqual = false;

            int counter = 0;

            for (int n1 = start; n1 <= end; n1++)
            {
                for (int n2 = start; n2 <= end; n2++)
                {
                    counter++;

                    if (n1 + n2 == number)
                    {
                        Console.WriteLine($"Combination N:{counter} ({n1} + {n2} = {number})");
                        isNumberEqual = true;
                        break;
                    }
                }
                if (isNumberEqual)
                {
                    break;
                }
            }
            if (isNumberEqual == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {number}");
            }
        }
    }
}
