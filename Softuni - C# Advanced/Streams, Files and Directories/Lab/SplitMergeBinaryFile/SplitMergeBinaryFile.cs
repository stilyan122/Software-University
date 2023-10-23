namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] data = File.ReadAllBytes(sourceFilePath);
            List<byte> data1 = new List<byte>();
            List<byte> data2 = new List<byte>();
            if (data.Length%2==0)
            {
                for (int i = 0; i < data.Length/2; i++)
                {
                    data1.Add(data[i]);
                }
                for (int i = data.Length/2; i < data.Length; i++)
                {
                    data2.Add(data[i]);
                }
            }
            else
            {
                for (int i = 0; i < data.Length/2+1; i++)
                {
                    data1.Add(data[i]);
                }
                for (int i = data.Length + 1; i < data.Length; i++)
                {
                    data2.Add(data[i]);
                }
            }
            using (StreamWriter writer = new StreamWriter(partOneFilePath))
            {
                foreach (var byteFile in data1)
                {
                    writer.WriteLine(byteFile);
                }
            }
            using (StreamWriter writer = new StreamWriter(partTwoFilePath))
            {
                foreach (var byteFile in data2)
                {
                    writer.WriteLine(byteFile);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] bytes1 = File.ReadAllBytes(partOneFilePath);
            byte[] bytes2 = File.ReadAllBytes(partTwoFilePath);
            IEnumerable<byte> copied = bytes1.Concat(bytes2);
            File.WriteAllBytes(joinedFilePath, copied.ToArray());  
        }
    }
}