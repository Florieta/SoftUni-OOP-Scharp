using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private IList<Character> characterParty;
		private Stack<Item> itemPool;

		public WarController()
		{
			characterParty = new List<Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];
            switch (characterType)
            {
				case "Warrior":
					characterParty.Add(new Warrior(name));
					break;
					case "Priest":
					characterParty.Add(new Priest(name));
					break;
				default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
					
            }

			return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			switch (itemName)
			{
				case "HealthPotion":
					itemPool.Push(new HealthPotion());
					break;
				case "FirePotion":
					itemPool.Push(new FirePotion());
					break;
				default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));

			}

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			Character character = characterParty.FirstOrDefault(c => c.Name == args[0]);

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}

			if (itemPool.Count == 0)
			{
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Item item = itemPool.Pop();
			character.Bag.AddItem(item);
			return string.Format(SuccessMessages.PickUpItem, args[0], item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			Character character = characterParty.FirstOrDefault(c => c.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			var sorted = characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);
			StringBuilder sb = new StringBuilder();
            foreach (var character in sorted)
            {
				sb.AppendLine(string.Format(SuccessMessages.CharacterStats,
				   character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			Character attacker = characterParty.FirstOrDefault(c => c.Name == args[0]);
			Character receiver = characterParty.FirstOrDefault(c => c.Name == args[1]);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));

			}
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}

			Warrior warrior = attacker as Warrior;

			if (warrior == null)
			{
				throw new ArgumentException(ExceptionMessages.AttackFail, args[0]);
			}

			warrior.Attack(receiver);

			string output = string.Format(SuccessMessages.AttackCharacter, warrior.Name, receiver.Name,
				warrior.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor,
				receiver.BaseArmor);

			if (receiver.Health == 0)
			{
				string temp = string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name);
				output = $"{output}\n{temp}";
			}

			return output;
		}

		public string Heal(string[] args)
		{
			Character healer = characterParty.FirstOrDefault(c => c.Name == args[0]);
			Character receiver = characterParty.FirstOrDefault(c => c.Name == args[1]);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));

			}
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}

			Priest priest = healer as Priest;

			if (priest == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, args[0]));
			}
			priest.Heal(receiver);
			return string.Format(SuccessMessages.HealCharacter, priest.Name, receiver.Name, priest.AbilityPoints,
				receiver.Name, receiver.Health);
		}
	}
}
