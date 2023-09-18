using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input with Name -> contest -> points
            // Save the track for each CONTEST and INDIVIDUAL POINTS of each user
            // add if the user is for first time
            // If the user already participated tkae the higher score otherwise add the score
            //Keep individual statistics of each user for each contest
            //Print each contest in order of input: "{constestName}: {participants.Count} participants"
            //print each user ordered by POINTS in descending order, after that in ascending order by NAME
            //Print individual statistics for every participant ordered by TOTAL POINTS in descending order and then by ALPHABETICAL Order.

            string input = string.Empty;

            Dictionary<string, Dictionary<string, int>> contestUserPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> usernameAndPoints = new Dictionary<string, int>();
            while (true)
            {
                input = Console.ReadLine();

                if (input == "no more time")
                {
                    break;
                }

                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);


                if (contestUserPoints.ContainsKey(contest))
                {
                    if (!contestUserPoints[contest].ContainsKey(username))
                    {
                        contestUserPoints[contest].Add(username, points);
                        continue;
                    }

                    if (contestUserPoints[contest][username] < points)
                    {
                        contestUserPoints[contest][username] = points;
                        continue;
                    }
                }
                else
                {
                    contestUserPoints.Add(contest, new Dictionary<string, int>() { { username, points } });

                }
            }


            foreach (var item in contestUserPoints)
            {
                foreach (var key in item.Value)
                {
                    if (usernameAndPoints.ContainsKey(key.Key))
                    {
                        usernameAndPoints[key.Key] += key.Value;
                    }
                    else
                    {
                        usernameAndPoints.Add(key.Key, key.Value);

                    }
                }
            }

            foreach (var item in contestUserPoints)
            {

                Console.WriteLine($"{item.Key}: {item.Value.Values.Count} participants");
            int position = 1;

                foreach (var contestant in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {

                    Console.WriteLine($"{position}. {contestant.Key} <::> {contestant.Value}");
                    position++;
                }
            }

            Console.WriteLine("Individual standings:");
            int standing = 1;
            foreach (var item in usernameAndPoints.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{standing}. {item.Key} -> {item.Value}");
                standing++;
            }

        }
    }
}
