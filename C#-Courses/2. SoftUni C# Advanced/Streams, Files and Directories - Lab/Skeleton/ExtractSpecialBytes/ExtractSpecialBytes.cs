namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] fileBytes;
            List<byte> byteToCheck = new List<byte>();
            using (StreamReader readerExample = new StreamReader(binaryFilePath))
            {
                fileBytes = File.ReadAllBytes(binaryFilePath);
                

            }

            using (StreamReader readerFile = new StreamReader(bytesFilePath))
            {

                while (!readerFile.EndOfStream)
                {
                    byteToCheck.Add((byte)int.Parse(readerFile.ReadLine()));

                }

                
            }

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var item in fileBytes)
                {
                    if (byteToCheck.Contains(item))
                    {
                        writer.WriteLine(item.ToString().Trim());
                    }
                }
            }

        }
    }
}
