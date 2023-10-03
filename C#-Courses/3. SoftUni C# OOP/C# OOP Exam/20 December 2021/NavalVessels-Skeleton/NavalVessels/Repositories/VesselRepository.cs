﻿using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> vessels;

        public VesselRepository()
        {
            this.vessels = new HashSet<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)this.vessels;

        public void Add(IVessel model)
        {
            this.vessels.Add(model);
        }
        public bool Remove(IVessel model) => this.vessels.Remove(model);


        public IVessel FindByName(string name) => this.vessels.FirstOrDefault(m => m.Name == name);
       

    }
}