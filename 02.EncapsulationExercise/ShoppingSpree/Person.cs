using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        private decimal money;

        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }

        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public void BuyProduct(Product product)
        {
            if (product.Cost > money)
            {
                throw new InvalidOperationException($"{Name} can't afford {product.Name}");
            }
            else
            {
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product}");
                bagOfProducts.Add(product);
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Count > 0)
            {
                return $"{Name} - {string.Join(", ", bagOfProducts)}";
            }
            return $"{Name} - Nothing bought";
        }
    }
}
