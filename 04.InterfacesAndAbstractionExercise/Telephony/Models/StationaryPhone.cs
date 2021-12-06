using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();

            }

            return $"Dialing... {phoneNumber}";
        }
    }
}
