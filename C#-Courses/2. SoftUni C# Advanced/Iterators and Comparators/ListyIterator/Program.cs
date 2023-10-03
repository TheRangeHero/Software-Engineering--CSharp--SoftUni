using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();


            ListyIterator<string> listyIterator = new ListyIterator<string>(input);

            string cmd;
            while ((cmd = Console.ReadLine())!="END")
            {
                switch (cmd)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException exception)
                        {

                            Console.WriteLine(exception.Message);
                        }
                        break;

                }
            }
        }
    }
}
