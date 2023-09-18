using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    class MulledWine : Cocktail
    {
        private const double LARGE_MULLEWINE = 13.50;

        public MulledWine(string name, string size) : base(name, size, LARGE_MULLEWINE)
        {

        }
    }
}
