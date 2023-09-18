using System;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumRight = 0;
            int sumLeft = 0;

            for (int i = 0; i < n; i++)
            {
                int right = int.Parse(Console.ReadLine());

                sumRight += right;                             
            }

            for (int i = 0; i < n; i++)
            {
                int left = int.Parse(Console.ReadLine());
                sumLeft += left;
            }

            if (sumRight == sumLeft)
            {
                Console.WriteLine($"Yes, sum = {sumRight} ");
            }
            else
            {
                int difference = sumRight - sumLeft;
                if (difference < 0)
                {
                    Console.WriteLine($"No, diff = {Math.Abs(difference)}");
                }
                else
                {
                    Console.WriteLine($"No, diff = {difference}");
                }

            }
        }
    }
}
