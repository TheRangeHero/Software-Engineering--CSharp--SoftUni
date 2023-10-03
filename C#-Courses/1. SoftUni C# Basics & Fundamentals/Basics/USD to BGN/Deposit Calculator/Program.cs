using System;

namespace Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int term = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());

            double sum = deposit + term * ((deposit * (interest / 100)) / 12);

            Console.WriteLine(sum);
        }
    }
}
