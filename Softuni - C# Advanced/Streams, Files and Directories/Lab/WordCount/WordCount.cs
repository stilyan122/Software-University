namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader reader1 = new StreamReader(wordsFilePath))
            {
                string[] words = reader1.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, int> occurences = new Dictionary<string, int>();
                using (StreamReader reader2 = new StreamReader(textFilePath))
                {
                    string textInput = reader2.ReadToEnd().ToUpper();
                    StringBuilder output = new StringBuilder();
                    string pattern = @"[A-Za-z]+";
                    MatchCollection matches = Regex.Matches(textInput, pattern);
                    foreach (var match in matches)
                    {
                        output.Append(match.ToString()+" ");
                    }
                    List<string>text = output.ToString().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (var word in words)
                    {
                        for (int i = 0; i < text.Count; i++)
                        {
                            if (text[i].ToUpper() == word.ToUpper())
                            {
                                text.RemoveAt(i);
                                i--;
                                if (!occurences.ContainsKey(word))
                                {
                                    occurences.Add(word, 1);
                                }
                                else
                                {
                                    occurences[word]++;
                                }
                            }
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var word in occurences.OrderByDescending(x=>x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
