namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
            using (StreamReader input = new StreamReader(bytesFilePath))
            {
                List<byte> bytes = new List<byte>();
                string line = input.ReadLine();
                while (line!=null)
                {
                    bytes.Add(byte.Parse(line));
                    line = input.ReadLine();
                }
                byte[] data = File.ReadAllBytes(binaryFilePath);
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (var item in bytes)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (item==data[i])
                            {
                                writer.Write(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
