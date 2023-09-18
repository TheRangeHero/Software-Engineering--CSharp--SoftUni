using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFEE_PRICE = 3.50M;
        private double caffeine;
        public Coffee(string name, double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {

            Caffeine = caffeine;
        }

        public double Caffeine
        {
            get { return caffeine; }
            set { caffeine = value; }
        }

    }
}
