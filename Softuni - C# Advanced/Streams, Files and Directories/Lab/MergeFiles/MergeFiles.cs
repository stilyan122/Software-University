namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        List<string> lines1 = new List<string>();
                        string line1 = reader1.ReadLine();
                        while (line1 != null)
                        {
                            lines1.Add(line1);
                            line1 = reader1.ReadLine();
                        }
                        List<string> lines2 = new List<string>();
                        string line2 = reader2.ReadLine();
                        while (line2 != null)
                        {
                            lines2.Add(line2);
                            line2 = reader2.ReadLine();
                        }
                        if (lines2.Count > lines1.Count)
                        {
                            for (int i = 0; i < lines1.Count; i++)
                            {
                                writer.WriteLine(lines1[i]);
                                writer.WriteLine(lines2[i]);
                            }
                            for (int i = lines1.Count; i < lines2.Count; i++)
                            {
                                writer.WriteLine(lines2[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < lines2.Count; i++)
                            {
                                writer.WriteLine(lines1[i]);
                                writer.WriteLine(lines2[i]);
                            }
                            for (int i = lines2.Count; i < lines1.Count; i++)
                            {
                                writer.WriteLine(lines1[i]);
                            }
                        }
                    }
                }
            }
        }
    }
}
