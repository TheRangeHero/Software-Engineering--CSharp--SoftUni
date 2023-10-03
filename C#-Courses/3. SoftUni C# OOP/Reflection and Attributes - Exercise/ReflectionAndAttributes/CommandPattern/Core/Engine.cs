using CommandPattern.Core.Contracts;
using CommandPattern.IO;
using CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICommandInterpreter commandInterpreter;

        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }
        public Engine(ICommandInterpreter commandInterpreter) : this()
        {
            this.commandInterpreter = commandInterpreter;
        }


        public void Run()
        {

            while (true)
            {
                try
                {

                string inputLine = this.reader.ReadLine();
                string result = this.commandInterpreter.Read(inputLine);
                this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {

                    this.writer.WriteLine(ioe.Message);
                }
            }
        }
    }
}
