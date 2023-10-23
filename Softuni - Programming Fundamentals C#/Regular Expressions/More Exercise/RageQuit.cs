using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            foreach (Match match in Regex.Matches(Console.ReadLine().ToUpper(), @"([^\d]+)([\d]+)"))
            {
                for (int i = 0; i < int.Parse(match.Groups[2].Value); i++)
                {
                    output.Append(match.Groups[1].Value);
                }
            }
            Console.Write($"Unique symbols used: {output.ToString().Distinct().Count()}\n{output}");
        }
    }
}
