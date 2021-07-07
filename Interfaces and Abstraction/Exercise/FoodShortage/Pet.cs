using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Pet : IBirtheble
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}
