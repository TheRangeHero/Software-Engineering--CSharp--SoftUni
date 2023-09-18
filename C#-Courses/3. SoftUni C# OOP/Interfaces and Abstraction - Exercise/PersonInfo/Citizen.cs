
namespace PersonInfo
{
    using System;
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;


        public Citizen(string name, int age,string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }


        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be positive number!");
                }
                this.age = value;
            }
        }


    }
}
