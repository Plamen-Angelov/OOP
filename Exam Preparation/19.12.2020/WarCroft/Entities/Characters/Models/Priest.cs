﻿
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters.Models
{
    public class Priest : Character, IHealer
    {
        private const double baseHealth = 50;
        private const double baseArmor = 25;
        private const double abilityPoints = 40;

        public Priest(string name) 
            : base(name, baseHealth, baseArmor, abilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();

            if (character.IsAlive)
            {
                character.Health += this.AbilityPoints;

                if (character.Health > character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
            }
        }
    }
}
