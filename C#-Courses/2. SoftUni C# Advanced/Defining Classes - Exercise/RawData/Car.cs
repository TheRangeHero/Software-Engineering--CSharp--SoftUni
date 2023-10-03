using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;


        public Tire[] Tires { get; set; }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public Car(string model, int speed,int power,int weight,string type,
           float tire1Pressure,int tire1Age,
           float tire2Pressure, int tire2Age,
           float tire3Pressure,int tire3Age,
           float tire4Pressure,int tire4Age)
        {
            this.model = model;
            this.engine = new Engine { Speed = speed, Power = power };
            this.cargo = new Cargo { Weight = weight, Type = type };
            Tires = new Tire[4];
            Tires[0] = new Tire(tire1Pressure, tire1Age);
            Tires[1] = new Tire(tire2Pressure, tire2Age);
            Tires[2] = new Tire(tire3Pressure, tire3Age);
            Tires[3] = new Tire(tire4Pressure, tire4Age);

            
        }
    }
}
