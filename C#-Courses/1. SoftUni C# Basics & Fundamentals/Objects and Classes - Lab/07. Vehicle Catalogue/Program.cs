using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            while (true)
            {


                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }


                string[] tokens = input.Split('/');
                string type = tokens[0];

                switch (type)
                {
                    case "Car":
                        Car car = new Car
                        {
                            TypeAndBrand = tokens[1],
                            Model = tokens[2],
                            HorsePower = int.Parse(tokens[3])
                        };
                        catalog.Cars.Add(car);
                        break;

                    case "Truck":
                        Truck truck = new Truck();
                        truck.TypeAndBrand = tokens[1];
                        truck.Model = tokens[2];
                        truck.Weight = int.Parse(tokens[3]);
                        catalog.Trucks.Add(truck);
                        break;
                }



            }

            if (catalog.Cars.Count > 0)
            {
                List<Car> orderedCars = catalog.Cars.OrderBy(Car => Car.TypeAndBrand).ToList();

                Console.WriteLine("Cars:");

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.TypeAndBrand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalog.Trucks.OrderBy(truck => truck.TypeAndBrand).ToList();

                Console.WriteLine("Trucks:");

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.TypeAndBrand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }

    class Truck
    {
        public string TypeAndBrand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string TypeAndBrand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }


    class Catalog
    {
        public Catalog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }


        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }
    }




}
