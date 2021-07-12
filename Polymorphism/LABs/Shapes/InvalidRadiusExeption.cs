using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class InvalidRadiusExeption : Exception
    {
        private const string ExeptionMessage = "Radius must be positive number!";
        public InvalidRadiusExeption() 
            : base(ExeptionMessage)
        {
        }
    }
}
