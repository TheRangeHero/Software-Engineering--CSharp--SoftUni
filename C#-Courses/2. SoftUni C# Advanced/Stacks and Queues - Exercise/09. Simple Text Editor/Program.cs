using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> memory = new Stack<string>();
            memory.Push(string.Empty);
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string[] cmds = Console.ReadLine().Split();

                string cmdType = cmds[0];


                if (cmdType == "1")
                {
                    string cmdValue = cmds[1];
                    text.Append(cmdValue);
                    memory.Push(text.ToString());
                }
                else if (cmdType == "2")
                {
                    int charToRemove = int.Parse(cmds[1]);
                    text.Remove(text.Length - charToRemove, charToRemove);
                    //string modifiedText = text.ToString().Substring(0, text.Length - charToRemove);
                    //text = new StringBuilder(modifiedText);
                    memory.Push(text.ToString());
                }
                else if (cmdType == "3")
                {
                    int index = int.Parse(cmds[1]);

                    if (index >=1 && index <= text.Length)
                    {
                        Console.WriteLine(text[index-1]);
                    }
                }
                else if (cmdType == "4")
                {
                    memory.Pop();
                    string previousVersion = memory.Peek();

                    text = new StringBuilder(previousVersion);
                }



            }
        }
    }
}
