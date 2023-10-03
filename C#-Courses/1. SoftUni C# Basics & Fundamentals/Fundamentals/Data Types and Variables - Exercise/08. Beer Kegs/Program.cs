using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string biggestKeg = "";
            double biggestVolume = 0;
            for (int i = 0; i < n; i++)
            {

                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                

                double volume = Math.PI * Math.Pow(radius, 2) * (double)height;

                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestKeg = model;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
