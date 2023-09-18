using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    class Gingerbread : Delicacy
    {
        private const double GINGERBREAD_PRICE = 4.00;

        public Gingerbread(string name) : base(name, GINGERBREAD_PRICE)
        {
        }
    }
}
