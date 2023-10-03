using System;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());

            double result = 0.0;

            if (symbol == '+' || symbol == '-' || symbol == '*')
            {
                if (symbol == '+')
                {
                    result = n1 + n2;
                }

                else if (symbol == '-')
                {
                    result = n1 - n2;
                }

                else if (symbol == '*')
                {
                    result = n1 * n2;
                }

                string oddOrEven = "odd";
                if (result % 2 == 0) // Проверка дали е четен резултата 
                {
                    oddOrEven = "even";
                }

                Console.WriteLine($"{n1} {symbol} {n2} = {result} - {oddOrEven}");
            }

            else if (symbol == '/' || symbol == '%')
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }

                else if (symbol == '/')
                {
                    result = 1.0 * n1 / n2; // При делене на 2 ( int ) ако искаме (double) резултат умножавам едното по 1.0 за да го превърнем в ( double )
                    Console.WriteLine($"{n1} {symbol} {n2} = {result:f2}");
                }

                else if (symbol == '%')
                {
                    result = n1 % n2;
                    Console.WriteLine($"{n1} {symbol} {n2} = {result}");
                }

            }
        }
    }
}
