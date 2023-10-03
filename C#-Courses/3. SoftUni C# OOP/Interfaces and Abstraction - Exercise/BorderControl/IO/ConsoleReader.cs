namespace BorderControl.IO
{
using System;

using BorderControl.IO.Interfaces;
    class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();        
    }
}
