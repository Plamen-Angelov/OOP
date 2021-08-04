using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Models
{
    public abstract class Bag : IBag
    {
        private List<Item> items = new List<Item>();

        public int Capacity { get; set; } = 100;

        public int Load => Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items { get; private set; }

        public Bag(int capacity)
        {
            Capacity = capacity;
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if ((Load + item.Weight) > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
            Items = items;
        }

        public Item GetItem(string name)
        {
            if (items.Any() == false)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(item);
            Items = items;
            return item;
        }
    }
}
