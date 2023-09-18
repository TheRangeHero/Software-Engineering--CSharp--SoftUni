
namespace FootballTeamGenerator
{
    using System;
    using System.Linq;
    public class Player
    {
        private string name;


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;

            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExeptionMessages.NameCannotBeNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public Stats Stats { get; private set; }
        public double OverallRating => (this.Stats.Endurance + this.Stats.Sprint
            + this.Stats.Dribble + this.Stats.Passing + this.Stats.Shooting) / 5.0;

    }
}
