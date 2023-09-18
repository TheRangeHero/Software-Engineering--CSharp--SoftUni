using System.Collections.Generic;
using System.Text;

namespace Vehicles.Exceptions
{
    using System;
    class InvalidVehicleType : Exception
    {
        private const string DEFAUL_MESSAGE = "Vehicle type not supported!";
        public InvalidVehicleType() : base(DEFAUL_MESSAGE)
        {

        }

        public InvalidVehicleType(string message) : base(message)
        {

        }

    }
}
