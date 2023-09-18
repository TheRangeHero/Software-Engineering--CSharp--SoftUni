using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    class BoxingGloves : Equipment
    {
        private const double BOXING_GLOVES_WEIGHT = 227;
        private const decimal BOXING_GLOVES_PRICE = 120;

        public BoxingGloves() 
            : base(BOXING_GLOVES_WEIGHT, BOXING_GLOVES_PRICE) { }
    }
}
