using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string Invalid_Phonenumber_Exception_Message = "Invalid number!";
        public InvalidPhoneNumberException()
            :base(Invalid_Phonenumber_Exception_Message)
        {
        }
    }
}
