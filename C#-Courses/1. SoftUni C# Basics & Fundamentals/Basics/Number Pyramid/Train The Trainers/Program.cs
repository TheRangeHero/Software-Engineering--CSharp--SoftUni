using System;

public class Program
{
    public static void Main()
    {
        int people = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        double seasonAvr = 0;
        int counter = 0;
        while (input != "Finish")
        {
            double grade = 0;

            for (int i = 0; i < people; i++)
            {
                grade += double.Parse(Console.ReadLine());
            }
            double gradeAvr = grade / people;
            seasonAvr += gradeAvr;
            counter++;
            Console.WriteLine($"{input} - {gradeAvr:f2}.");

            input = Console.ReadLine();
        }
        Console.WriteLine($"Student's final assessment is {(seasonAvr / counter):f2}.");
    }
}