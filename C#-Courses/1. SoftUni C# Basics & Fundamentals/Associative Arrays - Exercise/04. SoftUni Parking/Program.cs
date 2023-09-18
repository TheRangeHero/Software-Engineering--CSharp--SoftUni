using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string actions = commands[0];
                string userName = commands[1];

                switch (actions)
                {
                    case "register":
                        var plateNumber = commands[2];
                        if (CheckIfUserNameExists(users, userName))
                        {
                            users.Add(userName, plateNumber);
                            PrintResult($"{userName} registered {plateNumber} successfully");
                        }
                        else
                        {
                            PrintResult($"ERROR: already registered with plate number {plateNumber}");
                        }
                        break;
                    case "unregister":
                        if (CheckIfUserNameExists(users, userName))
                        {
                            PrintResult($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            PrintResult($"{userName} unregistered successfully");
                            users.Remove(userName);
                        }
                        break;
                }
            }

            foreach (var user in users)
            {
                PrintResult($"{user.Key} => {user.Value}");
            }
        }

        static bool CheckIfUserNameExists(Dictionary<string, string> users, string name) //=> !users.ContainsKey(name);
        {
            if (!users.ContainsKey(name))
            {
                return true;
            }
            return false;
        }
        

        static void PrintResult(string result) // => Console.WriteLine(result);
        {
            Console.WriteLine(result);
        }

    }
}
