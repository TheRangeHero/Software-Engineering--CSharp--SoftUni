using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> key = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = string.Empty;
            int position = 0;
            while (true)
            {
                List<char> message = new List<char>();
                StringBuilder type = new StringBuilder();
                StringBuilder coo = new StringBuilder();
                input = Console.ReadLine();
                if (input == "find")
                {
                    break;
                }

                for (int i = key.Count; i < input.Length; i++)
                {
                    key.Add(key[position]);
                    position++;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    message.Add((char)(input[i] - key[i]));
                }


                int startOfType = message.IndexOf('&');
                startOfType = ++startOfType;
                int endOfType = message.LastIndexOf('&');
                for (int i = startOfType; i < endOfType; i++)
                {
                    type.Append(message[i]);
                }

                int startOfCoo = message.IndexOf('<');
                startOfCoo = ++startOfCoo;
                int endOfCoo = message.LastIndexOf('>');
                for (int i = startOfCoo; i < endOfCoo; i++)
                {
                    coo.Append(message[i]);
                }

                Console.WriteLine($"Found {type} at {coo}");

            }


        }
    }
}
