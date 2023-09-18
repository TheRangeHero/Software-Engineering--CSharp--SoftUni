using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int leftElementsSum = 0;
            int rightElementsSum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                leftElementsSum = 0;
                for (int leftSum = i; leftSum > 0; leftSum--)
                {
                    int nextLeftElementPosition = leftSum - 1;
                    if (leftSum > 0)
                    {
                        leftElementsSum += number[nextLeftElementPosition];
                    }
                }

                rightElementsSum = 0;
                for (int rightSum = i; rightSum < number.Length; rightSum++)
                {
                    int nextRightElementPosition = rightSum + 1;
                    if (rightSum < number.Length-1)
                    {
                        rightElementsSum += number[nextRightElementPosition];
                    }
                }

                if (leftElementsSum == rightElementsSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
