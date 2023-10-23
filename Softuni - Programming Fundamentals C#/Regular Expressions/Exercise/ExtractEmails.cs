using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";
            Regex regex = new Regex(pattern);
            MatchCollection collection = regex.Matches(input);
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
