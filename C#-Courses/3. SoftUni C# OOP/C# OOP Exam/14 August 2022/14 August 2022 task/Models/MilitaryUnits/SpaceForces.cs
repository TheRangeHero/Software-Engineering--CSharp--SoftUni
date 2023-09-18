using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    class SpaceForces : MilitaryUnit
    {
        private const double SPACE_FORCES_COST = 11;

        public SpaceForces() 
            : base(SPACE_FORCES_COST) { }
    }
}
