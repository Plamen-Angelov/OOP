using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseble
    {
        public void Browsing(string URL)
        {
            Console.WriteLine($"Browsing: {URL}!");
        }

        public void Calling(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
