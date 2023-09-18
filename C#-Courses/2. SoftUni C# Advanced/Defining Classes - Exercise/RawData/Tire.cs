using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Tire
    {
        private float pressure;
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public float Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }


        public Tire(float pressure,int age)
        {
            this.pressure = pressure;
            this.age = age;
        }       
        
    }
}
