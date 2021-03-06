using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; }

        public string Country { get; }

        public int Age { get; }

        string IPerson.GetName()
        {
            return Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
