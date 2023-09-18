using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAUL_FUEL_CONSUMPTION = 1.25;

        public Vehicle(int hotesePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = HorsePower;
        }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual double FuelConsumption => DEFAUL_FUEL_CONSUMPTION;  //{ get { return DEFAUL_FUEL_CONSUMPTION; }  }

        public virtual void Drive(double kilometers)
        {
            double fuelLeft = Fuel - FuelConsumption * kilometers;

            if (fuelLeft>=0) //  if (fuelLeft >= 0) Fuel -= FuelConsumption * kilometers;
            {
                Fuel = fuelLeft;
            }
            
        }
    }
}
