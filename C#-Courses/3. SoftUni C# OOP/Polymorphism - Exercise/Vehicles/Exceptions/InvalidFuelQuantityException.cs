
namespace Vehicles.Exceptions
{
    using System;
    class InvalidFuelQuantityException : Exception
    {
        public InvalidFuelQuantityException(string message) : base(message)
        {
        }
    }
}
