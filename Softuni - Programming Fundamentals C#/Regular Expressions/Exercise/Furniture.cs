using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Furniture
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            string pattern = @"((>>)(?<name>[A-Za-z]+)(<<)(?<price>[0-9]+\.*[0-9]*)!(?<quantity>[0-9]+))\b";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            double sum = 0.0;
            Console.WriteLine("Bought furniture:");
            while (input != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string name = match.Groups["name"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    double quantity = double.Parse(match.Groups["quantity"].Value);
                    double total = price * quantity;
                    sum += total;
                    names.Add(name);
                }
                input = Console.ReadLine();
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
