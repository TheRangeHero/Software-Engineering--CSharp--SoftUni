using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            char operand = char.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());

            Console.WriteLine(OperationOfNumbers(numOne, operand, numTwo));

        }

        static double OperationOfNumbers(int numOne, char @operator, int numTwo)
        {
            double result = 0;

            switch (@operator)
            {
                case '+':
                    result = numOne + numTwo;
                    break;
                case '-':
                    result = numOne - numTwo;
                    break;
                case '*':
                    result = numOne * numTwo;
                    break;
                case '/':
                    result = numOne / numTwo;
                    break;
            }

            return result;
        }
    }
}
