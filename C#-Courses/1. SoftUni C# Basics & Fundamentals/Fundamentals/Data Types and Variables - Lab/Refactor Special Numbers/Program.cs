using System;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRange = int.Parse(Console.ReadLine());

            bool isSpecialNumber = false;

            for (int i = 1; i <= numberRange; i++)

            {

                int specialNumber = i;
                int specialNUmberSum = 0;
                while (specialNumber != 0)

                {
                    specialNUmberSum += specialNumber % 10;
                    specialNumber = specialNumber / 10;

                }

                isSpecialNumber = (specialNUmberSum == 5) || (specialNUmberSum == 7) || (specialNUmberSum == 11);

                Console.WriteLine("{0} -> {1}", i, isSpecialNumber);
            }
        }
    }
}
