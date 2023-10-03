using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            int power = 0;
            for (int i = 0; i < input.Length; i++)
            {

                char current = input[i];


                if (current =='>')
                {
                     power += int.Parse(input[i + 1].ToString());
                    result.Append(current);
                }
                else if (power == 0)
                {
                    result.Append(current);
                }
                else
                {
                    power--;
                }
            }

            Console.WriteLine(result);
        }
    }
}
