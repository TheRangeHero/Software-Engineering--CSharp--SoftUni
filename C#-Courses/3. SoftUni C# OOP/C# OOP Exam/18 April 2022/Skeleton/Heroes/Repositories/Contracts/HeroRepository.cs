﻿using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories.Contracts
{
    class HeroRepository : IRepository<IHero>
    {
        private readonly Dictionary<string, IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new Dictionary<string, IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes.Values;

        public void Add(IHero model) => this.heroes.Add(model.Name, model);

        public IHero FindByName(string name)
        {
            if (this.heroes.ContainsKey(name))
            {
                return this.heroes[name];
            }
            return null; 
        }

        public bool Remove(IHero model)
        {
            if (this.heroes.ContainsKey(model.Name))
            {
                this.heroes.Remove(model.Name);
                return true;
            }

            return false;
        }
    }
}
