namespace Raiding.Exceptions
{
    using System;
    class InvalidHeroException : Exception
    {
        public InvalidHeroException(string message) : base(message)
        {

        }
    }
}
