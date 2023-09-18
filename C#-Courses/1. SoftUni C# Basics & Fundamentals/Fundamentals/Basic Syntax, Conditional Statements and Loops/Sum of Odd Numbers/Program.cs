using System;

namespace Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

                int sum = 0;

                for (int i = 0; i < n; i++) 
            {
                int number = (i*2)+1 ;
                Console.WriteLine(number);
                sum += number;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
