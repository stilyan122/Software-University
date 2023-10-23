using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class MatchPhoneNumber
    {
        static void Main(string[] args)
        {
            string pattern = @"((\+359 2 [0-9]{3} [0-9]{4})\b)|((\+359-2-[0-9]{3}-[0-9]{4})\b)";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);
            string[] phones = matches.Cast<Match>().Select(x=>x.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ",phones));
        }
    }
}
