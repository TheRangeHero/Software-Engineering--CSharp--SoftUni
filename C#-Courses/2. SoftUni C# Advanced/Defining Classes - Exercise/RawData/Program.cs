using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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

                Car car = new Car(carInfo[0],
                    int.Parse(carInfo[1]),
                    int.Parse(carInfo[2]),
                    int.Parse(carInfo[3]),
                    carInfo[4],
                    float.Parse(carInfo[5]),
                    int.Parse(carInfo[6]),
                    float.Parse(carInfo[7]),
                    int.Parse(carInfo[8]),
                    float.Parse(carInfo[9]),
                    int.Parse(carInfo[10]),
                    float.Parse(carInfo[11]),
                    int.Parse(carInfo[12]));

                cars.Add(car);
            }

            string command = Console.ReadLine();

            string[] filteredCarModels;

            if (command == "fragile")
            {
                filteredCarModels = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(c => c.Pressure < 1)).Select(c=>c.Model).ToArray();
            }
            else
            {
                filteredCarModels = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power>250).Select(c => c.Model).ToArray();
            }
            foreach (var carModel in filteredCarModels)
            {
                Console.WriteLine(carModel);
            }
        }
    }
}
