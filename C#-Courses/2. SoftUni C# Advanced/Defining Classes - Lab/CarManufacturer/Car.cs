using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.engine = engine;
            this.tires = tires;
        }

        public double Drive(double distance)
        {
            fuelQuantity -= ((distance * fuelConsumption)/100);

            return fuelQuantity;

        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {this.Make} ");
            sb.AppendLine($"Model: {this.Model} ");
            sb.AppendLine($"Year: {this.Year} ");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.AppendLine($"FuelQuantity: {this.fuelQuantity:f1}");

            return sb.ToString();
        }
    }
}
