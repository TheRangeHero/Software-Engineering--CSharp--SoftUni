using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < count; i++)
            {
                string[] peopleProps = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(peopleProps[0], int.Parse(peopleProps[1]));

                
                family.AddMember(person);
            }
           

            foreach (var item in family.OverThirtyYears())
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
