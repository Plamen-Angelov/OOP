using System;

namespace ValidPerson
{
    class InvalidPersonNameException : Exception
    {
        private const string text = "The name must contain only letters";

        public string TextMessage => text;

    }
}
