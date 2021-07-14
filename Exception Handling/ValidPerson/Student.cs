
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    class Student
    {
        private string name;

        public string Name
        {
            get { return name; }
            set 
            {
                foreach (var item in value)
                {
                    if (!char.IsLetter(item))
                    {
                        throw new InvalidPersonNameException();
                    }
                }
                name = value; 
            }
        }

        public string Email { get; set; }

        public Student(string name)
        {
            Name = name;
        }
    }
}
