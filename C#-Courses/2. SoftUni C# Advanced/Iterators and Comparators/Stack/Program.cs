using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string cmd;

            while ((cmd=Console.ReadLine())!="END")
            {
                string[] tokens = cmd.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                switch (action)
                {
                    case "Push":
                        string[] itemsToPush = tokens.Skip(1).ToArray();
                        foreach (var item in itemsToPush)
                        {
                            stack.Push(item);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException exeption)
                        {
                            Console.WriteLine(exeption.Message);
                           
                        }
                        break;
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
