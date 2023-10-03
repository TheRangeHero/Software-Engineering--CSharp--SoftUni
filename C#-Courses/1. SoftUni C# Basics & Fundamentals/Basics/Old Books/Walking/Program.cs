using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int stepsSum = 0;

            while (input != "Going home")
            { 
                stepsSum += int.Parse(input);

                if (stepsSum >= 10000)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            if (input == "Going home")
            {
                input = Console.ReadLine();
                stepsSum += int.Parse(input);
            }

            if (stepsSum < 10000)
            {
                Console.WriteLine($"{10000 - stepsSum} more steps to reach goal.");
            }

            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsSum-10000} steps over the goal!");
            }
        }
    }
}
