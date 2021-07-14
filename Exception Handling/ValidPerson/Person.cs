using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName
        {
            get { return firstName; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    //throw new ArgumentException("The fisrtName cannot be null or empty.");
                    throw new NameLenghtException();
                }
                firstName = value; 
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    //throw new ArgumentException("The lastName cannot be null or empty.");
                    throw new NameLenghtException();
                }
                lastName = value; 
            }
        }

        public int Age
        {
            get { return age; }
            private set 
            {
                if (value < 0 || value > 120)
                {
                    //throw new ArgumentOutOfRangeException("Age should be in the range [0 .. 120].");
                    throw new InvalidAgeException();
                }
                age = value; 
            }
        }
    }
}
