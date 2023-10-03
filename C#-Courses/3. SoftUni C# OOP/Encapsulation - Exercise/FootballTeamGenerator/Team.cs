
namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name) : this()
        {
            this.Name = name;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExeptionMessages.NameCannotBeNullOrWhiteSpace);
                }
                this.name = value;
            }
        }

        public int Rating => this.players.Count > 0 ? (int)Math.Round(this.players.Average(p => p.OverallRating), 0) : 0;

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExeptionMessages.RemovingMissingMessage, playerName, this.name));
            }
            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.name} - {this.Rating}";
        }
    }
}
