using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private List<Product> boughtProducts;  
        private string name;
        private double money;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            
            boughtProducts = new List<Product>();
        }

        public double Money
        {
            get { return money; }
           private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value;
            }
        }

        public string Name
        {
            get { return name; }
          private  set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }

        
        public IReadOnlyList<Product> BoughtProducts => boughtProducts.AsReadOnly();
   


        public void BuyProduct(Product product)
        {
            
            if (product.Cost > money)
            {
                throw new Exception($"{name} can't afford {product.Name}");
            }
            boughtProducts.Add(product);
            money -= product.Cost;
        }

        public override string ToString()
        {
            if (boughtProducts.Count == 0)
            {
                return $"{name} - Nothing bought";
            }

            var products = boughtProducts.Select(p => p.Name);

            return $"{name} - {string.Join(", ", products)}";
        }

    }
}
