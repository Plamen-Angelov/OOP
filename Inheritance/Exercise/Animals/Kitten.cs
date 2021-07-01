using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string KITTENGENDER = "Female";

        public Kitten(string name, int age) 
            : base(name, age, KITTENGENDER)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
