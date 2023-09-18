namespace Raiding.IO
{
    using System;

    using Raiding.IO.Interfaces;
    class ConsoleWriter : IWriter
    {
        public void WirteLine(object value) => Console.WriteLine(value.ToString());


        public void Write(object value) => Console.Write(value.ToString());

    }
}
