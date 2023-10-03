using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> addOne = numbers =>
             {
                 for (int i = 0; i < numbers.Length; i++)
                 {
                     numbers[i]++;
                 }
                 return numbers;
             };

            Func<int[], int[]> subtractOne = numbers =>
           {
               for (int i = 0; i < numbers.Length; i++)
               {
                   numbers[i]--;
               }
               return numbers;
           };

            Action<int[]> multiplyByTwo = numbers =>
           {
               for (int i = 0; i < numbers.Length; i++)
               {
                   numbers[i] *= 2;
               }
           };
            Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            string cmd = Console.ReadLine();
            while (true)
            {
                if (cmd == "end")
                {
                    break;
                }

                switch (cmd)
                {
                    case "add":
                        numbers = addOne(numbers);
                        break;
                    case "multiply":
                        multiplyByTwo(numbers);
                        break;
                    case "subtract":
                        numbers = subtractOne(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

                cmd = Console.ReadLine();
            }

        }
    }
}
