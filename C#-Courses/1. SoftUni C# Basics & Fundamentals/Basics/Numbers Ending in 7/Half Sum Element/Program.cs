using System;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numMax = int.MinValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;

                if (num > numMax)
                {
                    numMax = num;
                }
            }
            int numWithoutMax = sum - numMax;
            if (numMax == numWithoutMax)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {numMax}");
            }
            else
            {
               int diff = Math.Abs(numMax - numWithoutMax);
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
