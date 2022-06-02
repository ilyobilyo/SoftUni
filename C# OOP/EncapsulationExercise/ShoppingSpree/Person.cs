using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;

            products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }


        public bool AddProduct(Product product)
        {
            if (Money - product.Cost < 0)
            {
                return false;
            }

            Money -= product.Cost;
            products.Add(product);
            return true;
        }

        public override string ToString()
        {
            if (products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", products)}";
        }
    }
}
