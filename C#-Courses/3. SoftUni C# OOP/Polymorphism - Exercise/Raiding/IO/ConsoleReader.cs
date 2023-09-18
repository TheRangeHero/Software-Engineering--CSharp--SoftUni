namespace Raiding.IO
{
    using System;

    using Raiding.IO.Interfaces;
    class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();

    }
}
