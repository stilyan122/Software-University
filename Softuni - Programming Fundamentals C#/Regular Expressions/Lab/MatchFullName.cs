using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class MatchFullName
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(([A-Z]{1}[a-z]+){1} ([A-Z]{1}[a-z]+){1}\w)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(Console.ReadLine());
            foreach (var match in matches)
            {
                Console.Write(match.ToString()+" ");
            }
        }
    }
}
