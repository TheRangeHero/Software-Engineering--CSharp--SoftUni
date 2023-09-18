using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    class Kettlebell : Equipment
    {
        private const double KETTLEBELL_WEIGHT = 1000;
        private const decimal KETTLEBELL_PRICE = 80;

        public Kettlebell() : base(KETTLEBELL_WEIGHT, KETTLEBELL_PRICE) { }
    }
}
