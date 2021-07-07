using System;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            StationaryPhone phone = new StationaryPhone();
            Smartphone smartPhone = new Smartphone();

            string[] phoneNumbers = Console.ReadLine()
                .Split();
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string phoneNumber = phoneNumbers[i];

                if (phoneNumber.Any(c => !char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (phoneNumber.Length == 7)
                {
                    phone.Calling(phoneNumber);
                }
                else if (phoneNumber.Length == 10)
                {
                   
                    smartPhone.Calling(phoneNumber);
                }
            }

            string[] URLs = Console.ReadLine()
                .Split();

            for (int i = 0; i < URLs.Length; i++)
            {
                string currentURL = URLs[i];

                if (currentURL.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                smartPhone.Browsing(currentURL);
            }
        }
    }
}
