using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string contestPassword = Console.ReadLine();
            Dictionary<string, string> contestPasswordData = new Dictionary<string, string>();

            while (contestPassword != "end of contests")
            {
                string[] tokens = contestPassword.Split(":");
                string contest = tokens[0];
                string password = tokens[1];

                contestPasswordData.Add(contest, password);


                contestPassword = Console.ReadLine();
            }

            string contestants = string.Empty;
            
            Dictionary<string, Dictionary<string, int>> confirmContest = new Dictionary<string, Dictionary<string, int>>();


            while (true)
            {
                contestants = Console.ReadLine();

                if (contestants == "end of submissions")
                {
                    break;
                }

                string[] tokens = contestants.Split("=>");
                string attendedContest = tokens[0];
                string usedPassword = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);


                if (!contestPasswordData.ContainsKey(attendedContest))
                {
                    continue;
                }

                if (contestPasswordData[attendedContest].CompareTo(usedPassword) != 0)
                {
                    continue;
                }

                if (confirmContest.ContainsKey(username))
                {
                    if (!confirmContest[username].ContainsKey(attendedContest))
                    {
                    confirmContest[username].Add(attendedContest, points);
                        continue;
                    }

                    if (confirmContest[username][attendedContest]<points)
                    {
                        confirmContest[username][attendedContest] = points;
                    }

                }
                else
                {
                    confirmContest.Add(username, new Dictionary<string, int>() { { attendedContest, points } });
                }
            }

            string winner = confirmContest.OrderBy(x => x.Value.Values.Sum()).Last().Key;
            int maxPoints = confirmContest.OrderBy(x => x.Value.Values.Sum()).Last().Value.Values.Sum();

            Console.WriteLine($"Best candidate is {winner} with total {maxPoints} points.");

            Console.WriteLine("Ranking: ");

            foreach (var item in confirmContest.OrderBy(x=>x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var contest in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
