using System;

namespace Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string random = Console.ReadLine();

            for (int i =0;i<random.Length;i++)
            {
                Console.WriteLine(random[i]);
            }
        }
    }
}


/*string random = Console.ReadLine();

for (int i = 0; i < random.Length; i++)
{
    char letter = char[i]
    Console.WriteLine(letter);
}*/
