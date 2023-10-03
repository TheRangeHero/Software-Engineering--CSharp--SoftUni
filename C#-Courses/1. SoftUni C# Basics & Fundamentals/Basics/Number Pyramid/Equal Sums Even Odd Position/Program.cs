using System;

namespace Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            int oddSum;
            int evenSum;

            for (int i = n1; i <= n2; i++)
            {
                 oddSum=0;
                 evenSum=0;
                string currentNum = $"{i}";

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int number = int.Parse($"{currentNum[j]}");
                    if (j % 2 == 0)
                    {
                        evenSum += number;
                    }
                    else
                    {
                        oddSum += number;
                    }
                if (oddSum == evenSum)
                {
                    Console.Write($"{currentNum} ");
                }
                }
            }
        }
    }
}
