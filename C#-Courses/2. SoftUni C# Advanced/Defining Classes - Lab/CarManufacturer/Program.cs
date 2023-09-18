using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Tire[]> tiresForCar = new List<Tire[]>();
            List<Engine> engineForCar = new List<Engine>();
            List<Car> carList = new List<Car>();
            string commandTire = Console.ReadLine();


            while (true)
            {
                if (commandTire == "No more tires")
                {
                    break;
                }
                string[] tireInfo = commandTire.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Tire[] tires = new Tire[tireInfo.Length / 2];

                for (int i = 0; i < tireInfo.Length; i += 2)
                {
                    Tire currTire = new Tire(int.Parse(tireInfo[i]), double.Parse(tireInfo[i + 1]));
                    tires[i / 2] = currTire;
                }
                tiresForCar.Add(tires);

                commandTire = Console.ReadLine();
            }

            string commandEngine = Console.ReadLine();
            while (true)
            {
                if (commandEngine == "Engines done")
                {
                    break;
                }
                string[] engineInfo = commandEngine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int currHorsePower = int.Parse(engineInfo[0]);
                double currCubucCapacity = double.Parse(engineInfo[1]);
                Engine engine = new Engine(currHorsePower, currCubucCapacity);
                engineForCar.Add(engine);

                commandEngine = Console.ReadLine();
            }

            string printCar = Console.ReadLine();
            while (true)
            {
                if (printCar == "Show special")
                {
                    break;
                }
                string[] carInfo = printCar.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantityInfo = double.Parse(carInfo[3]);
                double fuelConsumptionInfo = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Car car = new Car(make, model, year, fuelQuantityInfo, fuelConsumptionInfo, engineForCar[engineIndex], tiresForCar[tiresIndex]);

                carList.Add(car);
                printCar = Console.ReadLine();
            }

            foreach (var car in carList)
            {
                double totalPressure = car.Tires.Sum(x => x.Pressure);
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && (totalPressure > 9 && totalPressure < 10)&& car.FuelQuantity>0)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }

        }
    }
}
