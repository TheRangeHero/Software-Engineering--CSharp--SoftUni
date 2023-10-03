using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            int totalCapacity = 255;
            int litersSum = 0;
            for (int i = 0; i < nLines; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                litersSum += liters;
                if (litersSum > totalCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    litersSum -= liters;
                }    
            }
            Console.WriteLine(litersSum);
        }
    }
}
