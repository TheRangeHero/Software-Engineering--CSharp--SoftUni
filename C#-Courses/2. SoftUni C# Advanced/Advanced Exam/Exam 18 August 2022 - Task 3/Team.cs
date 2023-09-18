using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players = new List<Player>();
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => players.Count;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;

            players = new List<Player>();
        }


        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (this.OpenPositions==0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating<80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }       
        }

        public bool RemovePlayer(string name)
        {
            Player targetedPlayer = this.players.FirstOrDefault(x => x.Name==name);

            if (targetedPlayer==null)
            {
                return false;
            }
            OpenPositions++;
            this.players.Remove(targetedPlayer);
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int countOfRemovedPlayers = 0;

            while (players.FirstOrDefault(x=>x.Position==position)!=null)
            {
                Player targetedPlayer = players.FirstOrDefault(x => x.Position == position);
                players.Remove(targetedPlayer);
                OpenPositions++;
                countOfRemovedPlayers++;
            }
            return countOfRemovedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            Player targetedPlayer = players.FirstOrDefault(x => x.Name == name);

            if (targetedPlayer==null)
            {
                return null;
            }
            targetedPlayer.Retired = true;
            return targetedPlayer;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardedPlayers = new List<Player>();

            foreach (var player in players.Where(x=>x.Games>=games))
            {
                awardedPlayers.Add(player);
            }
            return awardedPlayers;
        
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players.Where(x=>x.Retired!=true))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
