using System;

namespace Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int preparation = int.Parse(Console.ReadLine());
            int percentage = int.Parse(Console.ReadLine());

            double wholeSum = ((pens * 5.80) + (markers * 7.20) + (preparation * 1.20)) - ((pens * 5.80) + (markers * 7.20) + (preparation * 1.20)) * percentage / 100;

            Console.WriteLine(wholeSum);
        }
    }
}
