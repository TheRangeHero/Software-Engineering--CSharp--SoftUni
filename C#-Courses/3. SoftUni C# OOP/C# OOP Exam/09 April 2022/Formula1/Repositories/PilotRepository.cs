﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.models.AsReadOnly();
        public void Add(IPilot pilot)
        {
            models.Add(pilot);
        }
        public IPilot FindByName(string fullName)
        {
            return models.FirstOrDefault(c => c.FullName == fullName);
        }
        public bool Remove(IPilot pilot)
        {
            return this.models.Remove(pilot);
        }
    }
}
