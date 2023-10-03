using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core.Contracts
{
    class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }



        //----------------------------------------------------
        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);
            if (this.planets.FindByName(name) != default)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            this.planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);

        }

        //-----------------------------------------------------------
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            //Ka-Boom
            //if (unitTypeName != nameof(AnonymousImpactUnit) &&
            //    unitTypeName != nameof(SpaceForces) &&
            //    unitTypeName != nameof(StormTroopers))
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            //}

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            //Ka-Boom
            IMilitaryUnit unit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
                nameof(SpaceForces) => new SpaceForces(),
                nameof(StormTroopers) => new StormTroopers(),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName))
            };

            //IMilitaryUnit unit;

            //if (unitTypeName == nameof(SpaceForces))
            //{
            //    unit = new SpaceForces();
            //}
            //else if (unitTypeName == nameof(StormTroopers))
            //{
            //    unit = new StormTroopers();
            //}
            //else
            //{
            //    unit = new AnonymousImpactUnit();
            //}

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        //-------------------------------------------------------------------------------------
        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

           // Ka - Boom
            //if (weaponTypeName != nameof(BioChemicalWeapon)
            //    && weaponTypeName != nameof(NuclearWeapon)
            //    && weaponTypeName != nameof(SpaceMissiles))
            //{
            //    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            //}

            if (planet.Weapons.Any(x=>x.GetType().Name==weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = weaponTypeName switch
            {
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),
                nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName))

            };

            //IWeapon weapon;

            //if (weaponTypeName == nameof(NuclearWeapon))
            //{
            //    weapon = new NuclearWeapon(destructionLevel);
            //}
            //else if (weaponTypeName == nameof(SpaceMissiles))
            //{
            //    weapon = new SpaceMissiles(destructionLevel);
            //}
            //else
            //{
            //    weapon = new BioChemicalWeapon(destructionLevel);
            //}

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        //-----------------------------------------------
        public string SpecializeForces(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            double specializeCost = 1.25;
            planet.TrainArmy();
            planet.Spend(specializeCost);

            return string.Format(OutputMessages.ForcesUpgraded,planetName);

        }

        //----------------------------------------------------------
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);


            double firstHalfBudget = firstPlanet.Budget / 2;
            double secondHalfBudget = secondPlanet.Budget / 2;


            double firstTotalValue = firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(x => x.Price);
            double secondTotalValue = secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(x => x.Price);


            double firstTotalPower = firstPlanet.MilitaryPower;
            double secondTotalPower = secondPlanet.MilitaryPower;


            bool firstHasNuclear = firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));
            bool secondHasNuclear = secondPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));

            var firstNuclear = firstPlanet.Weapons
                .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));
            var secondNuclear = secondPlanet.Weapons
                .FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));

            if (firstTotalPower>secondTotalPower)
            {
                firstPlanet.Spend(firstHalfBudget);
                firstPlanet.Profit(secondHalfBudget);
                firstPlanet.Profit(secondTotalValue);

                planets.RemoveItem(secondPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (secondTotalPower>firstTotalPower)
            {
                secondPlanet.Spend(secondHalfBudget);
                secondPlanet.Profit(firstHalfBudget);
                secondPlanet.Profit(firstTotalValue);

                planets.RemoveItem(firstPlanet.Name);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            else
            {
                if (firstNuclear!=null)
                {
                    firstPlanet.Spend(firstHalfBudget);
                    firstPlanet.Profit(secondHalfBudget);
                    firstPlanet.Profit(secondTotalValue);

                    planets.RemoveItem(secondPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if (secondNuclear!=null)
                {
                    secondPlanet.Spend(secondHalfBudget);
                    secondPlanet.Profit(firstHalfBudget);
                    secondPlanet.Profit(firstTotalValue);

                    planets.RemoveItem(firstPlanet.Name);
                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                else if (firstNuclear != null && secondNuclear != null)
                {
                    firstPlanet.Spend(firstHalfBudget);
                    secondPlanet.Spend(secondHalfBudget);
                    return string.Format(OutputMessages.NoWinner);
                }
                else  
                {
                    firstPlanet.Spend(firstHalfBudget);
                    secondPlanet.Spend(secondHalfBudget);
                    return string.Format(OutputMessages.NoWinner);
                }
            }
            
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x=>x.MilitaryPower).ThenBy(x=>x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
