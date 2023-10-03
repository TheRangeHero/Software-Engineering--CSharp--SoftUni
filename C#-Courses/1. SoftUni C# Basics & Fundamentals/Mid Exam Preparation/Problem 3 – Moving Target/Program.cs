using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string commands = string.Empty;

            while (true)
            {
                commands = Console.ReadLine();
                string[] tokens = commands.Split();

                if (commands == "End")
                {
                    break;
                }

                switch (tokens[0])
                {
                    case "Shoot":
                        ShootTheTarget(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                    case "Add":
                        AddATarget(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                    case "Strike":
                        StrikeATarget(int.Parse(tokens[1]), int.Parse(tokens[2]), targets);
                        break;
                }

            }
            Console.WriteLine(string.Join("|",targets));
        }


        static void ShootTheTarget(int index, int power, List<int> targets)
        {
            if (index < 0 || index > targets.Count - 1)
            {
                return;
            }
            targets[index] -= power;
            if (targets[index] <= 0)
            {
                targets.RemoveAt(index);
            }

        }
        static void AddATarget(int index, int value, List<int> targets)
        {
            if (index < 0 || index > targets.Count - 1)
            {
                Console.WriteLine($"Invalid placement!");
                return;
            }
            targets.Insert(index, value);

        }
        static void StrikeATarget(int index, int radius, List<int> targets)
        {
            if (index - radius < 0 || index + radius > targets.Count - 1)
            {
                Console.WriteLine($"Strike missed!");
                return;
            }
            targets.RemoveRange(index-radius, radius*2+1);
        }
    }
}
