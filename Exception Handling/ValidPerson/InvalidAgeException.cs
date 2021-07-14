using System;

namespace ValidPerson
{
    class InvalidAgeException : Exception
    {
        private const string text = "Age should be between 0 and 120";

        public string GetMessage => text;

    }
}
