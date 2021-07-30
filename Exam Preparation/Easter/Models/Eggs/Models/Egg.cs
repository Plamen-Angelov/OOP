using Easter.Models.Eggs.Contracts;
using System;

namespace Easter.Models.Eggs.Models
{
   
    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Egg name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return energyRequired;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                energyRequired = value;
            }
        }

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public void GetColored()
        {
            energyRequired -= 10;
        }

        public bool IsDone()
        {
            if (energyRequired == 0)
            {
                return true;
            }

            return false;
        }
    }
}
