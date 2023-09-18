using System;

namespace Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesCount = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int hours = (pages / pagesCount) / days;

            Console.WriteLine(hours);
        }
    }
}
