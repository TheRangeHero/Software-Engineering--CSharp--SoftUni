using Formula1.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Formula1.IO
{
    class FileWriter : IWriter
    {
        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", false))
            {
                writer.Write("");
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
