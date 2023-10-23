namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] text = File.ReadAllLines(inputFilePath);
            string[] output = new string[text.Length];
            int counter = 0;
            foreach (var line in text)
            {
                int letters = Regex.Matches(line, @"[A-Za-z]").Count;
                int marks = Regex.Matches(line, @"[^A-Za-z ]").Count;
                output[counter] = $"Line {counter + 1}: {line} ({letters}) ({marks})";
                counter++;
            }
            File.WriteAllLines(outputFilePath, output);
        }
    }
}
