using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    class BioChemicalWeapon : Weapon
    {
        private const double WEAPON_PRICE = 3.2;

        public BioChemicalWeapon( int destructionLevel) 
            : base(WEAPON_PRICE, destructionLevel)
        {
        }
    }
}
