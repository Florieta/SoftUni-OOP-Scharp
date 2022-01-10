using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly IList<Item> internalItems;
        public Bag(int capacity)
        {
            Capacity = capacity;
            internalItems = new List<Item>();
            this.Items = new ReadOnlyCollection<Item>(internalItems);
        }

        public int Capacity { get; set; }


        public int Load => Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            internalItems.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!internalItems.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);

            }
            Item item = internalItems.FirstOrDefault(i => i.GetType().Name == name);
            if (item == null )
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));

            }

            internalItems.Remove(item);

            return item;
        }
    }
}
