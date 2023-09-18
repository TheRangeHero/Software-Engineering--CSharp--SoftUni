using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0] == "End")
                {
                    break;
                }

                VehicleType vehicleType;
                bool isVehicleTypeParseSuccessful = Enum.TryParse(inputArgs[0], true, out vehicleType);

                if (isVehicleTypeParseSuccessful)
                {
                    string vehicleModel = inputArgs[1];
                    string vehicleColor = inputArgs[2];
                    int vehicleHorsePowers = int.Parse(inputArgs[3]);


                    Vehicle vehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, vehicleHorsePowers);
                    vehicles.Add(vehicle);
                }
            }

            while (true)
            {
                string commands = Console.ReadLine();
                if (commands== "Close the Catalogue")
                {
                    break;
                }

                Vehicle desiredVehicle = vehicles.FirstOrDefault(vehicleModel => vehicleModel.Model == commands);

                Console.WriteLine(desiredVehicle);
            }

            List<Vehicle> cars = vehicles.Where(vehicle => vehicle.Type == VehicleType.Car).ToList();
            List<Vehicle> trucks = vehicles.Where(vehicle => vehicle.Type == VehicleType.Truck).ToList();


            double carsAvgHorsepower = cars.Count > 0 ? cars.Average(car => car.HorsePowers) : 0.00;
            double truckAvgHorsepower = trucks.Count > 0 ? trucks.Average(truck => truck.HorsePowers) : 0.00;


            Console.WriteLine($"Cars have average horsepower of: {carsAvgHorsepower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAvgHorsepower:f2}.");
        }
    }

    enum VehicleType
    {
        Car,
        Truck
    }

    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePowers = horsePower;

        }
        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePowers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {Type}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePowers}");

            return sb.ToString().TrimEnd();
        }
    }
}
