using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class InvalidSideEXeption : Exception
    {
        public InvalidSideEXeption(string message) 
            : base(message)
        {
        }
    }
}
