using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    class NuclearWeapon : Weapon
    {
        private const double WEAPON_PRICE = 15;

        public NuclearWeapon(int destructionLevel)
            : base(WEAPON_PRICE, destructionLevel)
        {
        }
    }
}
