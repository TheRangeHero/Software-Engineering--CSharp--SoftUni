using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split();


            string[] secondArray = Console.ReadLine()
                .Split();

            foreach (string currentElemnt in firstArray)
            {
                for (int i = 0; i < secondArray.Length; i++)
                {
                    string secondCurElement = secondArray[i];

                    if (currentElemnt == secondCurElement)
                    {
                        Console.Write($"{secondCurElement} ");
                        break;
                    }
                }
            }
        }
    }
}
