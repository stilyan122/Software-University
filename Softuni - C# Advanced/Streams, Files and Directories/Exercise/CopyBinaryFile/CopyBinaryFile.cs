namespace CopyBinaryFile
{
    using System;
    using System.IO;
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            var reader = new FileStream(inputFilePath, FileMode.Open);
            var writer = new FileStream(outputFilePath, FileMode.Append);
            reader.CopyTo(writer);
        }
    }
}
