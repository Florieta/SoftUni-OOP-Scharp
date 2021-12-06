using System;
using System.Linq;
using Telephony.Models;
using Telephony.Exceptions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split().ToArray();

            string[] urls = Console.ReadLine().Split().ToArray();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string phoneNumber = phoneNumbers[i];
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumber)) ;
                    }
                    else
                    {
                        Console.WriteLine(smartphone.Call(phoneNumber));
                    }
                }
                catch (InvalidPhoneNumberException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                string url = urls[i];
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidURLException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
