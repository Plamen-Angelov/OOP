using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        private int power;
        private string type;

        protected BaseHero(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (value == "Druid" || value == "Rogue" || value == "Paladin" || value == "Warrior")
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException("Invalid hero!");
                }
            }
        }
        public string Name { get; }

        public virtual int Power 
        {
            get => this.power;
            private set
            {
                if (Type == "Druid" || Type == "Rogue")
                {
                    this.power = 80;
                }
                else if (Type == "Paladin" || Type == "Warrior")
                {
                    this.power = 100;
                }
            }
        }

        public virtual string CastAbility()
        {
            return $"{Type} – {Name} healed for {Power}";
        }
    }
}
