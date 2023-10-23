using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Race
{
    class Race
    {
        static void Main(string[] args)
        {
            string patternLetters = @"[A-Za-z]";
            string patternNumbers = @"[0-9]";
            Dictionary<string, int> racers = new Dictionary<string, int>();
            Regex regexLetters = new Regex(patternLetters);
            Regex regexNumbers = new Regex(patternNumbers);
            string[] names = Console.ReadLine().Split(", ");
            string input = Console.ReadLine();
            while (input!="end of race")
            {
                int sum = 0;
                StringBuilder builder = new StringBuilder();
                MatchCollection characters = regexLetters.Matches(input);
                MatchCollection numbers = regexNumbers.Matches(input);                
                foreach (var match in characters)
                {
                    builder.Append(match);
                }
                foreach (var match in numbers)
                {
                    sum += int.Parse(match.ToString());
                }
                if (names.Contains(builder.ToString()))
                {
                    if (!racers.ContainsKey(builder.ToString()))
                        racers.Add(builder.ToString(), sum);
                    else
                        racers[builder.ToString()] += sum;
                }
                input = Console.ReadLine();
            }
            racers = racers.OrderByDescending(x => x.Value).ToDictionary(k => k.Key,k=>k.Value);
            Console.WriteLine($"1st place: {racers.Keys.ToList()[0]}");
            Console.WriteLine($"2nd place: {racers.Keys.ToList()[1]}");
            Console.WriteLine($"3rd place: {racers.Keys.ToList()[2]}");
        }
    }
}
