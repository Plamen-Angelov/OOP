using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Characters.Models;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{

		private List<Character> characterParty = new List<Character>();
		private List<Item> itemPool = new List<Item>();

        public IFormatProvider SeccessMessages { get; private set; }

        public WarController()
		{
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			//Character character = null;

            if (characterType == "Warrior")
            {
				Warrior character = new Warrior(name);
				characterParty.Add(character);
			}
            else if (characterType == "Priest")
            {
				Priest character = new Priest(name);
				characterParty.Add(character);
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

			//characterParty.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;

            if (itemName == "HealthPotion")
            {
				item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
				item = new FirePotion();
            }
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

			itemPool.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = characterParty.First(c => c.Name == characterName);

			if (character == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            if (itemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = itemPool.Last();

			character.Bag.AddItem(item);

			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = characterParty.First(c => c.Name == characterName);
			Item item = character.Bag.GetItem(itemName);

            if (character == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

			character.UseItem(item);
			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

            foreach (var ch in characterParty
				.OrderByDescending(c => c.IsAlive == true)
				.ThenByDescending(c => c.Health))
            {
				string alive = string.Empty;
                if (ch.IsAlive)
                {
					alive = "Alive";
                }
                else
                {
					alive = "Dead";
                }

				sb.AppendLine($"{ ch.Name} - HP: { ch.Health}/{ ch.BaseHealth}, AP: { ch.Armor}/{ ch.BaseArmor}, " +
					$"Status: { alive}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = characterParty.FirstOrDefault(c => c.Name == attackerName);

            if (attacker == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
            }

			Character receiver = characterParty.FirstOrDefault(c => c.Name == receiverName);

			if (receiver == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, receiverName);
			}

            if (attacker.GetType().Name == "Priest")
            {
				throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }

			Warrior attackerWarrior = attacker as Warrior;
			attackerWarrior.Attack(receiver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{attackerName} attacks {receiverName} for {attackerWarrior.AbilityPoints} hit points!");
			sb.AppendLine($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP " +
				$"and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
				sb.AppendLine($"{ receiver.Name} is dead!");
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			Character healer = characterParty.FirstOrDefault(c => c.Name == healerName);

            if (healer == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
            }

			Character receiver = characterParty.FirstOrDefault(c => c.Name == receiverName);

			if (receiver == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
			}

            if (healer.GetType().Name == "Warrior")
            {
				throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
            }

			Priest healerPriest = healer as Priest;

			healerPriest.Heal(receiver);

			return $"{healerPriest.Name} heals {receiver.Name} for {healer.AbilityPoints}! " +
				$"{receiver.Name} has {receiver.Health} health now!";
		}
	}
}
