namespace BorderControl.IO
{
using System;

using BorderControl.IO.Interfaces;
    class ConsoleWriter : IWriter
    {
        public void Write(object value)
        {
            Console.Write(value.ToString());
        }

        public void WriteLine(object value) => Console.WriteLine(value.ToString());
        
    }
}
