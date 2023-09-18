using System;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentNum = 1;
            bool isEqual = false;

            for (int i = 0; i < n; i++) //0
            {
                for (int j = 0; j <= i; j++)//0<0
                {
                    Console.Write(currentNum+" ");
                    currentNum++;
                    if (currentNum > n)
                    {
                        isEqual = true;
                        break;
                    }
                }
                Console.WriteLine();
                if (isEqual)
                {
                   break;
                }
            }
        }
    }
}
