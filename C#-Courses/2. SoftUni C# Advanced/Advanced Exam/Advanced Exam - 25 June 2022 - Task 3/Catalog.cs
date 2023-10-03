using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }
        public string Name { get; private set; }
        public int NeededRenovators { get; private set; }
        public string Project { get; private set; }      


        public int Count => renovators.Count(); // {get{return renovators.Count}}


        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var targetedRenovator = renovators.FirstOrDefault(x => x.Name == name);
            //if (targetedRenovator == null)
            //{
            //    return false;
            //}
            //renovators.Remove(targetedRenovator);
            //return true;

            return renovators.Remove(targetedRenovator);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            //int count = 0;
            //while (renovators.FirstOrDefault(x => x.Type == type) != null)
            //{
            //    var tahrgetedRenovator = renovators.FirstOrDefault(x => x.Type == type);
            //    renovators.Remove(tahrgetedRenovator);
            //    count++;
            //}
            //return count;

            List<Renovator> leftRenovator = renovators.Where(t => t.Type != type).ToList();

            int removedCount = Count - leftRenovator.Count;
            renovators = leftRenovator;
            return  removedCount;
        }

        public Renovator HireRenovator(string name)
        {
            var targetedRenovator = renovators.FirstOrDefault(x => x.Name == name);

            if (targetedRenovator == null)
            {
                return null;
            }
            renovators.FirstOrDefault(x => x.Name == name).Hired = true;
            return targetedRenovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> paidRenovators = new List<Renovator>();
            foreach (var item in renovators.Where(x => x.Days >= days))
            {
                paidRenovators.Add(item);
            }

            return paidRenovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var item in renovators.Where(x => x.Hired == false))//.Where(x => x.Paid == false))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }

}

