using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Tomcat : Cat
    {
        private const string TOMCATGENDER = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, TOMCATGENDER)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
