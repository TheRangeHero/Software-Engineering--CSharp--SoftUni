using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> startsWithCapital = w => char.IsUpper(w[0]);

            string[] input = Array
                .FindAll(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries), startsWithCapital);


            input.ToList().ForEach(s => Console.WriteLine(s));
           // Console.WriteLine(string.Join(Environment.NewLine,input));
            
        }
    }
}
