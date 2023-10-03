using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string [] engineProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = EngineCreation(engineProperties);

                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = CarCreation(carProperties,engines);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public static Engine EngineCreation(string[] engineProperties)
        {
            Engine engine = new Engine(engineProperties[0], int.Parse(engineProperties[1]));

            if (engineProperties.Length>2)
            {
            int displacement;
            bool isDigit = int.TryParse(engineProperties[2], out displacement);

                if (isDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = engineProperties[2];
                }

                if (engineProperties.Length>3)
                {
                    engine.Efficiency = engineProperties[3];
                }

            }
            return engine;
        }

        public static Car CarCreation(string [] carProperties, List<Engine> engines)
        {
            Engine engine = engines.Find(x => x.Model == carProperties[1]);
            Car car = new Car(carProperties[0], engine);

            if (carProperties.Length>2)
            {
                int weight;

                bool isDigit = int.TryParse(carProperties[2], out weight);


                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carProperties[2];
                }

                if (carProperties.Length>3)
                {
                    car.Color = carProperties[3];
                }
            }

            return car;
        }
    }
}
