using System;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string answer = "";

            if (number % 10 == 0)
            {
                answer = "The number is divisible by 10";
            }
            else if (number % 7 == 0)
            {
                answer = "The number is divisible by 7";
            }
            else if (number % 6 == 0)
            {
                answer = "The number is divisible by 6";
            }
            else if (number % 3 == 0)
            {
                answer = "The number is divisible by 3";
            }
            else if (number % 2 == 0)
            {
                answer = "The number is divisible by 2";
            }
            else
            {
                answer = "Not divisible";
            }

            Console.WriteLine(answer);
        }
    }
}
