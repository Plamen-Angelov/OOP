using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies.Models
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;

        public string Name 
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = value;
                }
            }
        }

        public ICollection<IDye> Dyes { get; }

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Dyes = new List<IDye>();
        }

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }

        public abstract void Work();
    }
}
