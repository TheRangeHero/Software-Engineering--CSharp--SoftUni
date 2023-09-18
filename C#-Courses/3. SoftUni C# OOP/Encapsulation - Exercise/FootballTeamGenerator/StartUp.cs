using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
   public class StartUp
    {
        private static List<Team> teamList;
        static void Main(string[] args)
        {
            teamList = new List<Team>();

            RunEngine();

        }

        static Player CretateNewPlayer(string[] cmdArgs)
        {
            string playerName = cmdArgs[2];
            int endurance = int.Parse(cmdArgs[3]);
            int sprint = int.Parse(cmdArgs[4]);
            int dribbel = int.Parse(cmdArgs[5]);
            int passing = int.Parse(cmdArgs[6]);
            int shooting = int.Parse(cmdArgs[7]);

            Player newPlayer = new Player(playerName, endurance, sprint, dribbel, passing, shooting);

            return newPlayer;
        }

        static void AddNewTeam(string teamName)
        {
            Team newTeam = new Team(teamName);
            teamList.Add(newTeam);
        }

        static void AddPlayerToTeam(string teamName, string[] cmdArgs)
        {
            Team joiningTeam = teamList.FirstOrDefault(t => t.Name == teamName);
            if (joiningTeam == null)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.InexistingTeamMessage, teamName));
            }
            Player joiningPlayer = CretateNewPlayer(cmdArgs);
            joiningTeam.AddPlayer(joiningPlayer);
        }

        static void RemovePlayerFromTeam(string teamName, string playerName)
        {
            Team removingTeam = teamList.FirstOrDefault(t => t.Name == teamName);
            if (removingTeam == null)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.InexistingTeamMessage, teamName));
            }

            removingTeam.RemovePlayer(playerName);
        }

        static void RateTeam(string teamName)
        {
            Team teamToRate = teamList.FirstOrDefault(t => t.Name == teamName);
            if (teamToRate == null)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.InexistingTeamMessage, teamName));
            }
            Console.WriteLine(teamToRate);
        }

        static void RunEngine()
        {
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd.Split(';');
                string cmdType = cmdArgs[0];
                string teamName = cmdArgs[1];
                try
                {

                    if (cmdType == "Team")
                    {
                        AddNewTeam(teamName);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToTeam(teamName, cmdArgs);
                    }
                    else if (cmdType == "Remove")
                    {
                        string playerName = cmdArgs[2];

                        RemovePlayerFromTeam(teamName, playerName);
                    }
                    else if (cmdType == "Rating")
                    {
                        RateTeam(teamName);
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
