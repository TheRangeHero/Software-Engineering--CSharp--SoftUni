using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {

                int specialNum = 0;
                int currentNum = i;

                while (currentNum != 0)
                {
                   specialNum += currentNum % 10;
                    currentNum = currentNum / 10;
                }

                if (specialNum == 5 || specialNum == 7 || specialNum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
