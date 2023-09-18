using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();

            string cmd;

            while ((cmd=Console.ReadLine())!="END")
            {

                string[] personProps = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person
                {
                    Name = personProps[0],
                    Age = int.Parse(personProps[1]),
                    Town = personProps[2]
                };

                peoples.Add(person);
            }

            int compareIndex = int.Parse(Console.ReadLine())-1;


            Person personToCompare = peoples[compareIndex];


            int equal = 0;
            int diff = 0;

            foreach (var person in peoples)
            {
                if (person.CompareTo(personToCompare)==0)
                {
                    equal++;
                }
                else
                {
                    diff++;
                }
            }

            if (equal==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {diff} {peoples.Count}");
            }
        }
    }
}
