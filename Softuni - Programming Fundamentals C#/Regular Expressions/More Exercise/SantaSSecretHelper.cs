using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SantaSSecretHelper
{
    class SantaSSecretHelper
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string pattern = @"[^@\-\!\.\\:>]*@(?<name>[A-Za-z]+)[^@\-\!\.\>\:]*\![^@\-\!\.\>\:]*(?<category>G|N)[^@\-\!\.\>\:]*\![^@\-\!\.\>\:]*";
            Regex regex = new Regex(pattern);
            List<string> goodKids = new List<string>();
            while (input!="end")
            {
                StringBuilder subtracted = new StringBuilder();
                foreach (var item in input)
                {
                    char current = (char)((int)(item) - key);
                    subtracted.Append(current);
                }
                if (regex.IsMatch(subtracted.ToString()))
                {
                    Match match = regex.Match(subtracted.ToString());
                    string name = match.Groups["name"].Value;
                    string behaviour = match.Groups["category"].Value;
                    if (behaviour=="G")
                    {
                        goodKids.Add(name);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var kid in goodKids)
            {
                Console.WriteLine(kid);
            }
        }
    }
}
