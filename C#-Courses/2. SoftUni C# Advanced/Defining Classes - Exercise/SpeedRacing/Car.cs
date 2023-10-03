using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelConsumptionPerKilometer;
        private double fuelAmount;
        private double travelledDistance;
        
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public Car(string model,double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumption;
            this.travelledDistance = 0;
        }


        public void DriveCar(double distance)
        {
            double fuelToDistance = distance * this.fuelConsumptionPerKilometer;
            if (fuelToDistance>fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            fuelAmount -= fuelToDistance;
            travelledDistance += distance;
        }

        public void CarPrint()
        {
            Console.WriteLine($"{Model} {FuelAmount:f2} {TravelledDistance}");


        }

    }
}
