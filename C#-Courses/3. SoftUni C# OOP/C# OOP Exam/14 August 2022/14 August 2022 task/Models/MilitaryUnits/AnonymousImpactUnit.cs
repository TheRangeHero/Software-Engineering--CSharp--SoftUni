using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    class AnonymousImpactUnit : MilitaryUnit
    {
        private const double ANONYMOUSE_IMPACT_UNIT = 30;

        public AnonymousImpactUnit()
            : base(ANONYMOUSE_IMPACT_UNIT) { }
    }
}
