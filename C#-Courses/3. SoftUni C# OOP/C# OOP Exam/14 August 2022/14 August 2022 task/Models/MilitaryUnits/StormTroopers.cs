using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    class StormTroopers : MilitaryUnit
    {
        private const double STORM_TROOPERS_COST = 2.5;

        public StormTroopers() 
            : base(STORM_TROOPERS_COST) { }
    }
}
