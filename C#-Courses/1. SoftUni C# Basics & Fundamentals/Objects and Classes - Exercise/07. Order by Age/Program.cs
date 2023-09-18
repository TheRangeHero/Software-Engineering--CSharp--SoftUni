using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>();
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "End")
                {
                    break;
                }

                Person person = new Person(commands[0], commands[1], int.Parse(commands[2]));
                personsList.Add(person);
            }

            personsList.OrderBy(person => person.Age).ToList().ForEach(person => Console.WriteLine(person));

            //foreach (Person person in personsList.OrderBy(person=>person.Age))
            //{
             //   Console.WriteLine(person);
            //}
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
