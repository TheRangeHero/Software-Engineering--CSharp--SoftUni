using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            string damagePattern = @"-?\d+\.?\d*";
            string multiplyDividePattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";
            string input = Console.ReadLine();

            string[] demons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();

            for (int i = 0; i < demons.Length; i++)
            {
                string currDemon = demons[i];

                var healthMatched = Regex.Matches(currDemon, healthPattern);
                var health = 0;

                foreach (Match match in healthMatched)
                {
                    char curChar = char.Parse(match.ToString());
                    health += curChar;
                }


                double damage = 0;
                var damageMatched = Regex.Matches(currDemon, damagePattern);

                foreach (Match match in damageMatched)
                {
                    double currDamage = double.Parse(match.ToString());
                    damage += currDamage;
                }


                var multiplyAndDividers = Regex.Matches(currDemon, multiplyDividePattern);

                foreach  (Match match in multiplyAndDividers)
                {
                    char currentOperator = char.Parse(match.ToString());
                    if (currentOperator == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                Console.WriteLine($"{currDemon} - {health} health, {damage:f2} damage");

            }
        }
    }
}
