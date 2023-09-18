using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
   public abstract class Weapon : IWeapon
    {
        private int damage;
        private string name;
        private int durability;

        protected Weapon(string name, int durability,int damage)
        {
            Name = name;
            Durability = durability;
            this.Damage = damage;
        }

        public string Name
        {
            get { return name; }
           private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                name = value;
            }
        }
        public int Durability
        {
            get { return durability; }
           private set 
            {
                if (value<0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value; 
            }
        }
        private int Damage
        {
            get { return damage; }
             set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Damage cannot be below 0.");
                }
                damage = value;
            }
        }

        public int DoDamage()
        {
            this.Durability--;
            if (this.Durability==0)
            {
                return 0;
            }

            return this.Damage;
        }
    }
}
