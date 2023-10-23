using System;
using System.Text.RegularExpressions;

namespace SoftuniBarIncome
{
    class SoftuniBarIncome
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";
            double totalIncome = 0;
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            while (input != "end of shift")
            {
 
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);
                    double money = price * count;
                    Console.WriteLine($"{customer}: {product} - {money:F2}");
                    totalIncome += money;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}