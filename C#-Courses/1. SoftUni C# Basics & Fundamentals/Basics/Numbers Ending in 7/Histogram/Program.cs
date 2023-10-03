using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num <= 199)
                {
                    //p++
                    //p1=p1+1
                    p1 += 1;
                }

                else if (num >= 200 && num <= 399)
                {
                    p2 += 1;
                }

                else if (num >= 400 && num <= 599)
                {
                    p3 += 1;
                }

                else if (num >= 600 && num <= 799)
                {
                    p4 += 1;
                }

                else
                {
                    p5 += 1;
                }
            }

            p1 = p1 / n * 100;
            p2 = p2 / n * 100;
            p3 = p3 / n * 100;
            p4 = p4 / n * 100;
            p5 = p5 / n * 100;
            Console.WriteLine($"{p1:F2}% \n{p2:F2}% \n{p3:F2}% \n{p4:F2}% \n{p5:F2}% ");
        }
    }
}
