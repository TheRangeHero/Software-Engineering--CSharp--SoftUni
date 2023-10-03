using System;
using System.Linq;

namespace Problem_2___The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleQueue = int.Parse(Console.ReadLine());

            int[] wagonsSpaces = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < wagonsSpaces.Length; i++)
            {
                while (wagonsSpaces[i]<4 && peopleQueue>0)
                {
                    wagonsSpaces[i]++;
                    peopleQueue--;
                }                

            }
            if (peopleQueue == 0 && wagonsSpaces[wagonsSpaces.Length-1] == 4)
            {
                Console.WriteLine(string.Join(" ", wagonsSpaces));
                //Array.ForEach(wagonsSpaces, Console.Write);
            }
            else if (peopleQueue == 0 && wagonsSpaces[wagonsSpaces.Length-1] < 4)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagonsSpaces));
                //Array.ForEach(wagonsSpaces, Console.Write);
            }
            else if (peopleQueue > 0 && wagonsSpaces[wagonsSpaces.Length-1] == 4)
            {
                Console.WriteLine($"There isn't enough space! {peopleQueue} people in a queue!");
                Console.WriteLine(string.Join(" ", wagonsSpaces));
                //Array.ForEach(wagonsSpaces, Console.Write);
            }
        }
    }
}
