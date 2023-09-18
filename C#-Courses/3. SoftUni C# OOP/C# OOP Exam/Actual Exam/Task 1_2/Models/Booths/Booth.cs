using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private double currentBill;
        private double turnover;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            this.CurrentBill = 0;
            this.IsReserved = false;
            this.Turnover = 0;
            this.DelicacyMenu = new DelicacyRepository();
            this.CocktailMenu = new CocktailRepository();
        }

        public int BoothId
        {
            get { return boothId; }
            set { boothId = value; }
            //check
        }
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }
        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }
        }

        public double Turnover
        {
            get { return turnover; }
            set { turnover = value; }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; }

        public IRepository<ICocktail> CocktailMenu { get; }

        public bool IsReserved { get; private set; }


        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }

        public void Charge()
        {
            this.Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.currentBill += amount;
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:f2} lv");

            sb.AppendLine($"-Cocktail menu:");
            foreach (var item in CocktailMenu.Models)
            {
                sb.AppendLine($"--{base.ToString()}");
            }
            sb.AppendLine($"-Delicacy menu:");   

            foreach (var item in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{base.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
