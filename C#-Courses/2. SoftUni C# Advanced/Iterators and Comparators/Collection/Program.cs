using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();

            ListyIterator<string> items = new ListyIterator<string>(input);

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                switch (cmd)
                {
                    case "Move":
                        Console.WriteLine(items.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(items.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            items.Print();
                        }
                        catch (InvalidOperationException exeption)
                        {

                            Console.WriteLine(exeption.Message);
                        }
                        break;
                    case "PrintAll":
                        foreach (var item in items)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
