using System;

namespace ValidPerson
{
    class NameLenghtException : Exception
    {
        private const string text = "The name cannot be null or empty";

        public string GetMessage => text;

    }
}
