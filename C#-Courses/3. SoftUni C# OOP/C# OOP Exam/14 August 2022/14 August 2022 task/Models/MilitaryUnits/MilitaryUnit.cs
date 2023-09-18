using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            this.EnduranceLevel = 1;
        }

        public double Cost
        {
            get { return cost; }
            private set { cost = value; }
        }
        //check2
        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            private set 
            {                
                enduranceLevel = value; 
            }
        }

        public void IncreaseEndurance()
        {
            if (this.enduranceLevel == 20)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
            this.enduranceLevel++;
        }
    }
}
