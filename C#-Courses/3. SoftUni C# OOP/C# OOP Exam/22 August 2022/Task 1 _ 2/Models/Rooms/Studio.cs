using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    class Studio : Room
    {
        private const int STUDIO_CAPACITY = 4;

        public Studio() : base(STUDIO_CAPACITY) { }
    }
}
