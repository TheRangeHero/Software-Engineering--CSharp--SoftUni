using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            int remainder = 0;
            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = bigNumber.Length-1; i >= 0; i--)
            {
                char currNum = bigNumber[i];

                int currAsDigit = int.Parse(currNum.ToString());

                int result = currAsDigit * multiplier + remainder;

                sb.Append(result % 10);

                remainder = result / 10;
            }

            if (remainder != 0)
            {
                sb.Append(remainder);
            }



            StringBuilder reversedString = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                reversedString.Append(sb[i]);
            }

            Console.WriteLine(reversedString);
        }
    }
}
