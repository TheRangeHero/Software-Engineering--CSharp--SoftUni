
namespace FootballTeamGenerator
{
    using System;
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;


        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }


        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(this.Endurance)));
                }
                endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(Sprint)));
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(Dribble)));
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(Passing)));
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExeptionMessages.InvalidStatMessage, nameof(Shooting)));
                }
                shooting = value;
            }
        }


        private bool IsStatInvalid(int value) => value < 0 || value > 100;

    }
}
