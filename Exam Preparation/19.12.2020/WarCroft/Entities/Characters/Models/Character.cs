using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory.Models;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double health;
        private double baseHealth;
        private double baseArmor;
        private double armor;

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
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
				name = value;
            } 
		}

        public double BaseHealth { get; }

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
               if (value <= 0)
               {
                    IsAlive = false;
               }

               health = Math.Min(value, baseHealth);
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get
            {
                return armor;
            } 
            set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                armor = value;
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            BaseHealth = health;
            BaseArmor = armor;
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (Armor > hitPoints)
            {
                Armor -= hitPoints;
            }
            else
            {
                Health -= (hitPoints - Armor);
                Armor = 0;
            }

            if (Health <= 0)
            {
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);


        }
    }
}