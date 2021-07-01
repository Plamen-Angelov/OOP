using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public string Name 
        {
            get 
            {
                return name;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            } 
        }

        public int Age 
        {
            get 
            {
                return age;
            }
            set
            {
                if (age <= 0 )
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            } 
        }

        public string Gender 
        {
            get 
            {
                return gender;
            }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public Animal (string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual void ProduceSound()
        { 

        }
    }
}
