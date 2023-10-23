namespace FolderSize
{
    using System;
    using System.IO;
    using System.Linq;

    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            float sizes = directory.GetFiles().Sum(x=>x.Length);
            DirectoryInfo[] sub = directory.GetDirectories();
            foreach (var item in sub)
            {
                sizes += item.GetFiles().Sum(x => x.Length);
            }
            double divided = sizes / 1024;
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.Write(divided + " KB");
            }
        }
    }
}
