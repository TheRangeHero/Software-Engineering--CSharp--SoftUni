using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] currStudentInfo = Console.ReadLine().Split();

                Student student = new Student(currStudentInfo[0], currStudentInfo[1], float.Parse(currStudentInfo[2]));

                students.Add(student);
            }

            students = students.OrderByDescending(currStudent => currStudent.Grade).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            /*foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }*/

            //students.ForEach(student => Console.WriteLine(student));
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, float grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public override string ToString() => $"{FirstName} {LastName}: {Grade:f2}";
        
    }
}
