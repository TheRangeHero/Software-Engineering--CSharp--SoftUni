using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            int input = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < input; i++)
            {
                string [] student = Console.ReadLine().Split();

                decimal grade = decimal.Parse(student[1]);

                if (!students.ContainsKey(student[0]))
                {
                    students.Add(student[0], new List<decimal>());
                }

                students[student[0]].Add(grade);
            }




            foreach (var item in students)
            {
                Console.Write($"{item.Key} ->");

                foreach (decimal grade in item.Value)
                {
                    Console.Write($" {grade:f2}");
                }

                Console.WriteLine($" (avg: {item.Value.Average():f2})");
            }

        }
    }
}
