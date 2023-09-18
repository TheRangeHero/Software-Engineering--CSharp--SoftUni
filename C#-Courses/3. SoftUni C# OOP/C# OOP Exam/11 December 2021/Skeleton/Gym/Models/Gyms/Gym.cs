using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    class Gym : IGym
    {
        private string name;
        private int capacity;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public double EquipmentWeight
        {
            get { return this.Equipment.Select(e=>e.Weight).Sum(); }
            
        }

        public ICollection<IEquipment> Equipment { get;  }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count>= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}");

            string athletes;
            if (Athletes.Count>0)
            {
                athletes = string.Join(", ", Athletes.Select(a => a.FullName));
            }
            else
            {
                athletes = "No athletes";
            }

            sb.AppendLine($"Athletes: {athletes}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");


            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {

            return this.Athletes.Remove(athlete);
        }
    }
}
