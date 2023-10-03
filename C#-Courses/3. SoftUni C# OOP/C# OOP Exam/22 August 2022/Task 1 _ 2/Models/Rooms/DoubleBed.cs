using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    class DoubleBed : Room
    {
        private const int DOUBLE_BED_CAPACITY = 2;

        public DoubleBed() : base(DOUBLE_BED_CAPACITY)
        {
        }
    }
}
