using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }
        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(this.CalculatePower(), 3);

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }
        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }
        public void Profit(double amount)
        {
            this.Budget += amount;
        }
        //check1
        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            var units = new List<string>();
            var equipment = new List<string>();

            foreach (var item in this.Army)
            {
                units.Add(item.GetType().Name);
            }
            foreach (var item in this.Weapons)
            {
                equipment.Add(item.GetType().Name);
            }

            string forcesResult = this.Army.Count == 0 ? "No units" : $"{string.Join(", ",units)}";
            string equipmentResult = this.Weapons.Count == 0 ? "No weapons" : $"{string.Join(", ", equipment)}";

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {forcesResult}");
            sb.AppendLine($"--Combat equipment: {equipmentResult}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");


            return sb.ToString().TrimEnd();
        }

        private double CalculatePower()
        {
            double result = this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return result;
        }
    }
}
