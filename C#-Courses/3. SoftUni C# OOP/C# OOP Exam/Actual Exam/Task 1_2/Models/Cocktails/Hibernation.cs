using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    class Hibernation : Cocktail
    {
         private const double LARGE_HIBERNATION = 10.50;

        public Hibernation(string name, string size) : base(name, size, LARGE_HIBERNATION)
        {
        }
    }
}
