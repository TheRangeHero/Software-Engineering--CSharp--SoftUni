using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string modelInfo = carInfo[0];
                double fuelAmountInfo = double.Parse(carInfo[1]);
                double fuelConsumptionInfo = double.Parse(carInfo[2]);

                Car car = new Car(modelInfo, fuelAmountInfo, fuelConsumptionInfo);
                cars.Add(car);
            }
            string command;
            while ((command=Console.ReadLine()) != "End")
            {
                string[] driveCmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = driveCmd[1];
                double distance = double.Parse(driveCmd[2]);

                cars.Find(x => x.Model == carModel).DriveCar(distance);


            }
            foreach (var car in cars)
            {
                car.CarPrint();
            }

        }
    }
}
