using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    class SpaceMissiles : Weapon
    {
        private const double WEAPON_PRICE = 8.75;

        public SpaceMissiles(int destructionLevel)
            : base(WEAPON_PRICE, destructionLevel)
        {
        }
    }
}
