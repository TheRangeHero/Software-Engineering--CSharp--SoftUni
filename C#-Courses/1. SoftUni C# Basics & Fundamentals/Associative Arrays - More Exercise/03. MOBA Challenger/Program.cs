using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerPositionSkills = new Dictionary<string, Dictionary<string, int>>();
            string input = string.Empty;
            string opponentOne = string.Empty;
            string opponentTwo = string.Empty;
            string player = string.Empty;
            string position = string.Empty;
            int skill = 0;
            while (true)
            {
                input = Console.ReadLine();
                string[] tokens = Array.Empty<string>();

                if (input == "Season end")
                    break;


                if (input.Contains("->"))
                {
                    tokens = input.Split(" -> ").ToArray();
                    player = tokens[0];
                    position = tokens[1];
                    skill = int.Parse(tokens[2]);

                    if (!playerPositionSkills.ContainsKey(player))
                    {
                        playerPositionSkills.Add(player, new Dictionary<string, int>() { { position, skill } });
                        continue;
                    }

                    if (!playerPositionSkills[player].ContainsKey(position) || playerPositionSkills[player][position] < skill)
                        playerPositionSkills[player][position] = skill;
                    continue;
                }

                if (input.Contains("vs"))
                {
                    tokens = input.Split(" vs ").ToArray();
                    opponentOne = tokens[0];
                    opponentTwo = tokens[1];

                    if (!playerPositionSkills.ContainsKey(opponentOne) || !playerPositionSkills.ContainsKey(opponentTwo))
                        continue;

                    if (playerPositionSkills[opponentOne].Keys.Any(pos => playerPositionSkills[opponentTwo].Keys.Contains(pos)))
                    {
                        if (playerPositionSkills[opponentOne].Values.Sum() > playerPositionSkills[opponentTwo].Values.Sum())
                            playerPositionSkills.Remove(opponentTwo);
                        else if (playerPositionSkills[opponentOne].Values.Sum() < playerPositionSkills[opponentTwo].Values.Sum())
                            playerPositionSkills.Remove(opponentOne);
                    }
                }

            }


            foreach (var item in playerPositionSkills.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");
                foreach (var key in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {key.Key} <::> {key.Value}");
                }
            }


        }
    }
}