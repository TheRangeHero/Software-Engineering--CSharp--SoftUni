namespace Telephony.Exceptions
{
using System;
   public class InvalidPhoneNumberExceptions:Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberExceptions(): base(DEFAULT_EXCEPTION_MESSAGE)
        {

        }

        public InvalidPhoneNumberExceptions(string message): base(message)
        {

        }
    }
}
