using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes.Contracts
{
    class Weightlifter : Athlete
    {
        private const int WEIGHTLIFTER_STAMINA = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, WEIGHTLIFTER_STAMINA, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            Stamina += 10;
        }
    }
}
