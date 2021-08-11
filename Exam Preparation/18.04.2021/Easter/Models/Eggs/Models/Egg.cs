using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

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
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
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
            private set
            {
                if (energyRequired < 0)
                {
                    energyRequired = 0;
                }
                else
                {
                    energyRequired = value;
                }
            }
        }

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public void GetColored()
        {
            EnergyRequired -= 10;

            if (EnergyRequired < 0)
            {
                EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            if (EnergyRequired == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
