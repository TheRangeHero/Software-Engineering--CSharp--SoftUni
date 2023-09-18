using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> studenDetails = new List<Student>();

            while (input != "end")
            {

                string[] studenInformation = input.Split();

                Student student = new Student(studenInformation[0], studenInformation[1], studenInformation[2], studenInformation[3]);
                //{
                //    FirstName = studenInformation[0],
                //    LastName = studenInformation[1],
                //    Age = studenInformation[2],
                //    HomeTown = studenInformation[3]
                //};

                studenDetails.Add(student);
                input = Console.ReadLine();
            }

            string cityName = Console.ReadLine();

            foreach (Student student in studenDetails)
            {
                if (cityName == student.HomeTown)
                {

                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }


        }

        class Student
        {
            
            public Student(string firstName, string lastName, string age, string homeTown)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
                this.HomeTown = homeTown;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Age { get; set; }
            public string HomeTown { get; set; }
        }
    }
}
