using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IBirtheble
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }

        public string Id { get; set; }
    }
}
