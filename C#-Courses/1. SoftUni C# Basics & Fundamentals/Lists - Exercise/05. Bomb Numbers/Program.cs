using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();


            List<int> specialNumber = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < sequence.Count; i++)
            {
                if (specialNumber[0] == sequence[i])
                {
                    BombNumber(sequence, specialNumber[1], i);
                }
            }
            Console.WriteLine(sequence.Sum());
        }

        private static void BombNumber(List<int> sequence, int power, int index)
        {
            int start = Math.Max(0, index - power);
            int end = Math.Min(sequence.Count - 1, index + power);

            for (int i = start; i <= end; i++)
            {
                sequence[i] = 0;
            }
        }
    }
}
