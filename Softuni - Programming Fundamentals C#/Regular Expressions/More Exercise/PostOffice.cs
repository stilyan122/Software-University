using System;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class PostOffice
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|");
            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];
            string firstPattern = @"([#$%*&])(?<capitals>[A-Z]+)(\1)";
            Regex regex1 = new Regex(firstPattern);
            Match firstMatch = regex1.Match(firstPart);
            string capitalLetters = firstMatch.Groups["capitals"].Value;
            for (int index = 0; index < capitalLetters.Length; index++)
            {
                char startLetter = capitalLetters[index];
                int code = startLetter;
                string secondPattern = $@"{code}:(?<length>[0-9][0-9])";
                Regex regex2 = new Regex(secondPattern);
                Match secondMatch = regex2.Match(secondPart);
                int length = int.Parse(secondMatch.Groups["length"].Value);
                string thirdPattern = $@"(?<=\s|^){startLetter}[^\s]{{{length}}}(?=\s|$)";
                Regex regex3 = new Regex(thirdPattern);
                Match thirdMatch = regex3.Match(thirdPart);
                string curr = thirdMatch.ToString();
                Console.WriteLine(curr);
            }
        }
    }
}
