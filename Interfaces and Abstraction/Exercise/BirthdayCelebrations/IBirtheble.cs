using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IBirtheble
    {
        string Name { get; set; }
        string BirthDate { get; set; }
    }
}
