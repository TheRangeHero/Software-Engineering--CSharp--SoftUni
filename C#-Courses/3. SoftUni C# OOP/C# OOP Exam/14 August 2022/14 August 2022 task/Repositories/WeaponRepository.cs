using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(x => x.GetType().Name == name);


        public bool RemoveItem(string name) => this.weapons.Remove(this.weapons.FirstOrDefault(x => x.GetType().Name == name));
    }
}
