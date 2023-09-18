using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    class Apartment : Room
    {
        private const int APARTAMENT_CAPACITY = 6;

        public Apartment() : base(APARTAMENT_CAPACITY)
        {
        }
    }
}
