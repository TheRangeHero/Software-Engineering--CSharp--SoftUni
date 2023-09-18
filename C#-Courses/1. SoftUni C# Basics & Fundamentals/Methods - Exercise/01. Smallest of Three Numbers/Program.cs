using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestNumber(numOne,numTwo,numThree));
            //PrintSmallestNumber(numOne, numTwo, numThree);
        }

        static int SmallestNumber(int numOne, int numTwo, int numThree)
        {
            return Math.Min(numOne, Math.Min(numTwo, numThree));
        }

        /*static void PrintSmallestNumber(int numOne, int numTwo, int numThree) => Console.WriteLine
            (Math.Min(numOne,Math.Min(numTwo,numThree)));*/
        
    }
}
