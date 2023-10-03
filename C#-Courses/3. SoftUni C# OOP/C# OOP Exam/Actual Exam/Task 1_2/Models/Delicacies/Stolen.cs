using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    class Stolen : Delicacy
    {
        private const double STOLEN_PRICE = 3.50;

        public Stolen(string name) : base(name, STOLEN_PRICE)
        { }
    }
}
