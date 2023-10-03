using System;

namespace Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            bool isGrade = grade >= 5.50 && grade <= 6.00;
            if (isGrade)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
