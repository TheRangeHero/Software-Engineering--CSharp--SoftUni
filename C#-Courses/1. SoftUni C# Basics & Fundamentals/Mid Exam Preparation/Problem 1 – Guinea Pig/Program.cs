using System;

namespace Problem_1___Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {
            float foodQuantity = float.Parse(Console.ReadLine());
            float hayQuantity = float.Parse(Console.ReadLine());
            float coverQuantity = float.Parse(Console.ReadLine());
            float weightQuantity = float.Parse(Console.ReadLine());


            for (int i = 1; i <= 30; i++)
            {
                foodQuantity -= 0.300f;

                if (i % 2 == 0)
                {
                    hayQuantity -= (float)((foodQuantity * 5) / 100);
                }

                if (i % 3 == 0)
                {
                    coverQuantity -= (float)(1.0 / 3.0 * weightQuantity);
                }
            }

            if (foodQuantity >= 0 && hayQuantity >= 0 && coverQuantity >= 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: { foodQuantity:f2}, Hay: { hayQuantity:f2}, Cover: { coverQuantity:f2}.");
            }
            else
            {

            Console.WriteLine($"Merry must go to the pet store!");
            }

        }
    }
}
