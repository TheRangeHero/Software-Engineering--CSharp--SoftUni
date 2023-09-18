
namespace Telephony.Exceptions
{
using System;
   public class InvalidURLException:Exception
    {
        private const string DEFAUL_MESSAGE = "Invalid URL!";

        public InvalidURLException(): base(DEFAUL_MESSAGE)
        {

        }

        public InvalidURLException(string message) : base(message)
        {

        }
    }
}
