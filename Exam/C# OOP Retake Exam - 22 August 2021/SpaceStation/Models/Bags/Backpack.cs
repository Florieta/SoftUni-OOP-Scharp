using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private List<string> items = new List<string>();
        public ICollection<string> Items => this.items;

        public override string ToString()
        {
            return this.Items.Count > 0 ? $"Bag items: {String.Join(", ", this.Items)}" : "Bag items: none";
        }
    }
}
