using CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.IO
{
    class ConsoleWriter : IWriter
    {
        public void Write(object value) => Console.Write(value.ToString());

        public void WriteLine(object value) => Console.WriteLine(value.ToString());
    }
}
