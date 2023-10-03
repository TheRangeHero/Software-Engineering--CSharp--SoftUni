using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            switch (size)
            {
                case "Large":
                    this.Price = price;
                        break;
                case "Middle":
                    this.Price = price*(2/3);
                    break;
                case "Small":
                    this.Price = price*(1/3);
                    break;

            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
            //check
        }
        public string Size
        {
            get { return size; }
            protected set { size = value; }
        }
        //check
        public double Price
        {
            get { return price; }
            protected set { price = value; }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.Size}) - {this.price:f2} lv");

            return sb.ToString().Trim();
        }
    }


}
