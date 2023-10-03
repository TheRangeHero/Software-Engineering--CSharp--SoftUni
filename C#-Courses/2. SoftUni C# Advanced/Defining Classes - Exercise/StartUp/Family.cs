using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    class Family
    {
        

        private List<Person> listOfPeople;

        public List<Person> ListOfPeople
        {
            get { return listOfPeople; }
            set { listOfPeople = value; }
        }

        public Family()
        {
            this.listOfPeople = new List<Person>();
        }

        public void AddMember(Person person)
        {

            this.listOfPeople.Add(person);
        }

        public Person GetOlderstMember()
        {
            return this.listOfPeople.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public List<Person> OverThirtyYears()
        {
            List<Person> overThirty = new List<Person>();
            foreach (var item in this.listOfPeople.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                overThirty.Add(item);
            }
            return overThirty;
        }
    }
}
