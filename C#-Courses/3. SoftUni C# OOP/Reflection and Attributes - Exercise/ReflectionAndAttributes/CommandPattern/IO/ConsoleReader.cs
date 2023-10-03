using CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.IO
{
    class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
